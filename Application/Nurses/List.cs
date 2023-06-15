using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Nurses
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<Nurse>>>
        {
            public PagingParams Params;

        }
        public class Handler : IRequestHandler<Query, Result<PagedList<Nurse>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<PagedList<Nurse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Nurses.OrderByDescending(d => d.IsRoundingManager)
                .ThenBy(d => d.FullName)
                .AsQueryable();
                return Result<PagedList<Nurse>>.Success(
                    await PagedList<Nurse>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}