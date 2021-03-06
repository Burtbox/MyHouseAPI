﻿using Microsoft.AspNetCore.Mvc;
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
        public enum HttpVerbs { Get, Put, Post, Delete };

        protected BaseController(
            IAuthorizationService authorizationService
        )
        {
            this.authorizationService = authorizationService;
        }

        /// <summary>
        /// /// A request handler for requests scoped to own user id
        /// </summary>
        /// <param name="userId">the request's user id to match to its claims</param>
        /// <param name="handleRequest">the function to run if valid request</param>
        /// <returns></returns>
        protected async Task<IActionResult> RequestHandler<T>(HttpVerbs method, string userId, Func<Task<T>> processRequest)
        {
            IActionResult response;

            try
            {
                AuthorizationResult authorizationResult = await authorizationService
                    .AuthorizeAsync(User, userId, "OwnUserId"); // secure on being that user here
                if (authorizationResult.Succeeded)
                {
                    switch (method)
                    {
                        case HttpVerbs.Get:
                        case HttpVerbs.Put:
                        case HttpVerbs.Post:
                            {
                                response = Ok(await processRequest());
                                break;
                            }
                        case HttpVerbs.Delete:
                            {
                                await processRequest();
                                response = NoContent();
                                break;
                            }
                        default:
                            {
                                response = BadRequest();
                                break;
                            }
                    }
                }
                else
                {
                    response = Forbid();
                }
            }
            catch (InvalidOccupantException)
            {
                response = Forbid();
            }
            catch (TimeoutException)
            {
                response = StatusCode(StatusCodes.Status408RequestTimeout, "The request has timed out, please try again");
            }
            catch (Exception exception)
            {
                var ex = exception; //Useful for debugging, avoids warning
                response = StatusCode(StatusCodes.Status500InternalServerError, "An error has occured.");
            }

            return response;
        }
    }
}
