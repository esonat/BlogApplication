using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Posts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery]PostParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query{Params = param}));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            return HandleResult(await Mediator.Send(new Create.Command {Post = post}));
        }
    }
}