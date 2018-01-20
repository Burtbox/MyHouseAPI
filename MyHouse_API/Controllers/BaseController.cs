using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MyHouseAPI.Repositories;
using MyHouseAPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Http;

namespace MyHouseAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IAuthorizationService authorizationService;

        protected BaseController(
            IAuthorizationService authorizationService
        )
        {
            this.authorizationService = authorizationService;
        }

        /// <summary>
        /// A request handler for requests scoped to own user id
        /// </summary>
        /// <param name="userId">the request's user id to match to its claims</param>
        /// <param name="handleRequest">the function to run if valid request</param>
        /// <returns></returns>
        protected async Task<IActionResult> RequestHandler<U, V, T>(string userId, Func<U, V, Task<T>> processRequest)
        {
            IActionResult response = NotFound();

            // try
            // {
            //     AuthorizationResult authorizationResult = await authorizationService
            //         .AuthorizeAsync(User, userId, "OwnUserId"); // secure on being that user here
            //     if (authorizationResult.Succeeded)
            //     {
            //         response = Ok(await processRequest());
            //     }
            //     else
            //     {
            //         response = new ForbidResult();
            //     }
            // }
            // catch (InvalidOccupantException)
            // {
            //     response = Forbid();
            // }
            // catch (Exception)
            // {
            //     response = StatusCode(StatusCodes.Status500InternalServerError, "An error has occured.");
            // }

            return response;
        }
    }
}