using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories.Houses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Model.Houses;
using Microsoft.AspNetCore.NodeServices;
using System;

namespace MyHouseAPI.Controllers
{
    [Route("api/Houses/[controller]")]
    [ApiVersion("3.0")]
    [Authorize]
    public class OccupantsController : BaseController
    {
        private readonly OccupantsRepository occupantsRepository;

        public OccupantsController(
            IAuthorizationService authorizationService,
            OccupantsRepository occupantsRepository
        ) : base(authorizationService)
        {
            this.occupantsRepository = occupantsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> RequestOccupantsOfHousehold([FromQuery] string userId, [FromQuery] int occupantId)
        {
            return await RequestHandler<IEnumerable<OccupantResponse>>(HttpVerbs.Get, userId, async () =>
                await occupantsRepository.GetOccupantsOfHousehold(userId, occupantId));
        }

        [HttpPost]
        public async Task<IActionResult> RequestInviteOccupant([FromBody] OccupantInviteRequest invitee)
        {
            return await RequestHandler<bool>(HttpVerbs.Put, invitee.InvitedByUserId, async () =>
                await occupantsRepository.InviteOccupant(invitee));
        }

        [HttpPut]
        public async Task<IActionResult> RequestUpdateOccupant([FromBody] OccupantUpdateRequest occupant)
        {
            return await RequestHandler<OccupantResponse>(HttpVerbs.Put, occupant.UserId, async () =>
                await occupantsRepository.UpdateOccupant(occupant));
        }

        //[HttpDelete("{userId},{householdId},{occupantId}")]
        // Removed delete method as don't want users to have to delete occupants (just to leave households)
        // public async Task<IActionResult> DeleteOccupant(string userId, int householdId, int occupantId)
        // {
        //     return await RequestHandler<int>(HttpVerbs.Delete, userId, async () =>
        //         await occupantsRepository.DeleteOccupant(userId, householdId, occupantId));
        // }
    }
}