using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery]ActivityParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query{Params = param}));
        }
    }
}