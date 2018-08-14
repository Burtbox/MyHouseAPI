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
using System.Reflection;

namespace MyHouseAPI.Repositories.Houses
{
    public class OccupantsRepository : BaseRepository
    {
        private readonly NewsFeedsRepository newsFeedsRepository;
        private readonly ILogger logger;
        public OccupantsRepository(ConnectionHandler connection, ILogger logger, NewsFeedsRepository newsFeedsRepository) : base(connection, logger)
        {
            this.newsFeedsRepository = newsFeedsRepository;
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
                return await InsertOccupantQuery(db, occupant);
            });
        }

        public async Task<OccupantResponse> InsertOccupantQuery(IDbConnection db, OccupantInsertRequest occupant)
        {
            OccupantResponse insertedOccupant = await db.QueryFirstAsync<OccupantResponse>(
                    sql: "[Houses].[Occupants_Insert]",
                    param: occupant,
                    commandType: CommandType.StoredProcedure
                );
            return insertedOccupant;
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
            // TODO: Send invite email!
            return await asyncConnection(invite.InvitedByUserId, invite.InvitedByOccupantId, async db =>
            {
                bool occupantInvited = false;
                OccupantInviteResponse existingOccupant = GetFirebaseUserByEmail(invite.Email);
                if (existingOccupant != null)
                {
                    this.logger.Information($"Creating Occupant from invite: {invite.ToString()}");
                    OccupantInsertRequest createOccupant = new OccupantInsertRequest
                    {
                        InviteAccepted = false,
                        UserId = existingOccupant.Uid,
                        DisplayName = existingOccupant.DisplayName,
                        EnteredBy = invite.InvitedByUserId,
                        InvitedByOccupantId = invite.InvitedByOccupantId
                    };
                    this.logger.Information($"Creating Occupant: {createOccupant.ToString()}");
                    OccupantResponse newOccupant = await this.InsertOccupantQuery(db, createOccupant);

                    this.logger.Information($"Created Occupant: {newOccupant.ToString()}");

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
                    this.logger.Information($"Creating News Feed Invite: {invite.ToString()}");
                    await newsFeedsRepository.InsertNewsFeedQuery(db, householdInviteNewsItem);
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
            this.logger.Information("get the node js firebase admin Bundle");
            var apiDirectory = Directory.GetParent(Assembly.GetEntryAssembly().Location);
            string firebaseAdminConsole = String.Concat(apiDirectory.FullName, "\\FirebaseAdmin\\firebaseAdminBundle.js");
            this.logger.Information($"Firebase Admin console looking for at path: {firebaseAdminConsole}");

            if (!File.Exists(firebaseAdminConsole))
            {
                this.logger.Error($"Firebase Admin console not found at path: {firebaseAdminConsole}");
                throw new Exception($"Firebase Admin console not found at path: {firebaseAdminConsole}");
            }

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
