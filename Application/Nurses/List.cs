using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Nurses
{
    public class List
    {
        public class Query: IRequest<List<Nurse>>  {

        }
        public class Handler : IRequestHandler<Query, List<Nurse>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context){
                _context = context;
            }
            public async Task<List<Nurse>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Nurses.ToListAsync();
            }
        }
    }
}