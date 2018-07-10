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
        public OccupantsRepository(ConnectionHandler connection, ILogger logger) : base(connection, logger) { }

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
            return await asyncConnection(occupant.EnteredBy, occupant.OccupantId, async db =>
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

        public async Task<OccupantInviteResponse> InviteOccupant(OccupantInviteRequest invite)
        {
            return await asyncConnection(invite.InvitedByUserId, invite.InvitedByOccupantId, async db =>
            {
                OccupantInviteResponse occupant = GetFirebaseUserByEmail(invite.Email);
                return occupant;
            });
        }

        private OccupantInviteResponse GetFirebaseUserByEmail(string userId)
        {
            // get the node js index file
            DirectoryInfo apiDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            string firebaseAdminConsole = String.Concat(apiDirectory.FullName, "\\MyHouse_FirebaseAdmin\\build\\index.js");
            string commandName = "getFirebaseUserByEmail";
            string args = string.Concat(firebaseAdminConsole, " ", commandName, " ", userId);

            //Run the command
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    FileName = "node.exe",
                    Arguments = args
                }
            };

            string jsonOccupantInviteResponse = process.StandardOutput.ReadToEnd();
            OccupantInviteResponse occupant = JsonConvert.DeserializeObject<OccupantInviteResponse>(jsonOccupantInviteResponse);

            return occupant;
        }

        // ED! This will be replaced with a leave household button
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
    }
}
