﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyHouseAPI.Repositories.Authorization;
using MyHouseAPI.Model.Authorization;

namespace MyHouseAPI.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiVersion("3.0")]
    [Authorize]
    public class AuthorizationController : BaseController
    {
        private readonly AuthorizationRepository authorizationRepository;
        public AuthorizationController(
            IAuthorizationService authorizationService,
            AuthorizationRepository authorizationRepository
        ) : base(authorizationService)
        {
            this.authorizationRepository = authorizationRepository;
        }

        // GET: api/values
        [HttpGet("{userId}")]
        public async Task<IActionResult> CheckAuthorization(string userId)
        {
            return await RequestHandler<AuthorizationResponse>(HttpVerbs.Get, userId, async () =>
                authorizationRepository.IsAuthorized(userId));
        }

        // GET: api/values
        [HttpGet("{userId},{occupantId}")]
        public async Task<IActionResult> CheckHouseholdAuthorization(string userId, int occupantId)
        {
            return await RequestHandler<AuthorizationResponse>(HttpVerbs.Get, userId, async () =>
                await authorizationRepository.IsHouseholdAuthorized(userId, occupantId));
        }
    }
}