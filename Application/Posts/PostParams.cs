using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Posts
{
    public class PostParams : PagingParams
    {
        public DateTime StartDate { get; set; } =  DateTime.UtcNow;
    }
}