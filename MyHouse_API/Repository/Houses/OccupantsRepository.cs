using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using MyHouseAPI.Handlers;
using MyHouseAPI.Model.Houses;
using Serilog;
using Newtonsoft.Json;

namespace MyHouseAPI.Repositories.Houses
{
    public class OccupantsRepository : BaseRepository
    {
        private readonly ConnectionHandler dbConnection;
        private readonly ILogger logger;
        public OccupantsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger)
        {
            this.dbConnection = connection;
            this.logger = logger;
        }

        public async Task<IEnumerable<OccupantResponse>> GetOccupantsOfHousehold(string userId, int occupantId)
        {
            return await asyncConnection(userId, occupantId, async db =>
            {
                IEnumerable<OccupantResponse> occupants = await db.QueryAsync<OccupantResponse>(
                    sql: "[Houses].[Occupants_Of_Household_Select]",
                    param: new { OccupantId = occupantId },
                    commandType: CommandType.StoredProcedure
                );
                return occupants;
            });
        }

        public async Task<OccupantResponse> InsertOccupant(OccupantInsertRequest occupant)
        {
            return await asyncConnection(occupant.EnteredBy, occupant.InvitedByOccupantId, async db =>
            {
                OccupantResponse insertedOccupant = await db.QueryFirstAsync<OccupantResponse>(
                    sql: "[Houses].[Occupants_Insert]",
                    param: occupant,
                    commandType: CommandType.StoredProcedure
                );
                return insertedOccupant;
            });
        }

        public async Task<OccupantResponse> UpdateOccupant(OccupantUpdateRequest occupant)
        {
            return await asyncConnection(occupant.UserId, occupant.OccupantId, async db =>
             {
                 OccupantResponse updatedOccupant = await db.QueryFirstAsync<OccupantResponse>(
                    sql: "[Houses].[Occupants_Update]",
                    param: occupant,
                    commandType: CommandType.StoredProcedure
                 );
                 return updatedOccupant;
             });
        }

        public async Task<bool> InviteOccupant(OccupantInviteRequest invite)
        {
            return await asyncConnection(invite.InvitedByUserId, invite.InvitedByOccupantId, async db =>
            {
                bool occupantInvited = false;
                // TODO: Send invite email!

                OccupantInviteResponse existingOccupant = GetFirebaseUserByEmail(invite.Email);
                if (existingOccupant != null)
                {
                    OccupantInsertRequest createOccupant = new OccupantInsertRequest
                    {
                        InviteAccepted = false,
                        UserId = existingOccupant.Uid,
                        DisplayName = existingOccupant.DisplayName,
                        EnteredBy = invite.InvitedByUserId,
                        InvitedByOccupantId = invite.InvitedByOccupantId
                    };
                    OccupantResponse newOccupant = await this.InsertOccupant(createOccupant);

                    NewsFeedsRepository newsFeeds = new NewsFeedsRepository(this.dbConnection, this.logger);
                    NewsFeedInsertRequest householdInviteNewsItem = new NewsFeedInsertRequest
                    {
                        EnteredBy = invite.InvitedByUserId,
                        OccupantId = invite.InvitedByOccupantId,
                        Headline = "Invited to a new household",
                        SubHeadline = "Congrats",
                        Story = "You have been invited to a new household! Go to households to accept the invite.",
                        Author = invite.InvitedByUserId,
                        Recipient = newOccupant.UserId,
                    };

                    await newsFeeds.InsertNewsFeed(householdInviteNewsItem);
                    occupantInvited = true;
                }
                else
                {
                    // TODO: Improve functionality here!
                    throw new Exception($"The email address {invite.Email} must sign up to myHouse first");
                }

                return occupantInvited;
            });
        }

        private OccupantInviteResponse GetFirebaseUserByEmail(string userId)
        {
            // get the node js index file
            DirectoryInfo apiDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            string firebaseAdminConsole = String.Concat(apiDirectory.FullName, "\\MyHouse_FirebaseAdmin\\build\\index.js");
            string commandName = "getFirebaseUserByEmail";
            string args = string.Concat(firebaseAdminConsole, " ", commandName, " ", userId);

            //Run the command
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    FileName = "C:\\Program Files\\nodejs\\node.exe",
                    Arguments = args
                }
            };
            process.Start();

            string jsonOccupantInviteResponse = process.StandardOutput.ReadToEnd();
            OccupantInviteResponse occupant = JsonConvert.DeserializeObject<OccupantInviteResponse>(jsonOccupantInviteResponse);

            return occupant;
        }

        // This can be used for deleting unaccpeted invites!
        // public async Task<int> DeleteOccupant(string userId, int householdId, int occupantId)
        // {
        //     return await asyncConnection(userId, occupantId, async db =>
        //     {
        //         int rowsDeleted = await db.ExecuteAsync(
        //             sql: "[Houses].[Occupants_Delete]",
        //             param: new { OccupantId = occupantId, HouseholdId = householdId },
        //             commandType: CommandType.StoredProcedure
        //         );
        //         return rowsDeleted;
        //     });
        // }

        // TODO:  Create a leave household flow
    }
}
