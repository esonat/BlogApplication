using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<PostDto>>>
        {
            
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<PostDto>>>
        {

            public List(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                
            }
            public Task<Result<PagedList<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}