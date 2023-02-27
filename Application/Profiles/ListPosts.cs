using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Posts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class ListPosts
    {
        public class Query : IRequest<Result<List<PostDto>>>
        {
            public string Username { get; set; }
            //public string Predicate { get; set; }
        }

       public class Handler : IRequestHandler<Query,
Result<List<PostDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
            _context = context;
        }

            public async Task<Result<List<PostDto>>> Handle(Query
                request, CancellationToken cancellationToken)
                {
                var query = _context.Posts
                .Where(u => u.User.UserName == request.Username)
                .OrderBy(a => a.Date)
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

                // query = request.Predicate switch
                // {
                //     "past" => query.Where(a => a.Date <= DateTime.UtcNow),
                //     "hosting" => query.Where(a => a.HostUsername ==
                //     request.Username),
                //     _ => query.Where(a => a.Date >= DateTime.UtcNow)
                // };
                var posts = await query.ToListAsync();
                return Result<List<PostDto>>.Success(posts);
            }
        }
    }
}