using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfilesController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Username = username}));
        }

        [HttpGet("{username}/posts")]
        public async Task<IActionResult> GetUserPosts(string username,
            string predicate)
        {
            return HandleResult(await Mediator.Send(new ListPosts.Query
            { Username = username }));
        }
    }
}