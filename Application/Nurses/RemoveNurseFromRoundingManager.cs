using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Nurses
{
    public class RemoveNurseFromRoundingManager
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

        }
        public class Handler : IRequestHandler<Command>
        {
            public readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var nurse = await _context.Nurses.FindAsync(request.Id);
                if(!nurse.IsRoundingManager){
                    throw new Exception("Nurse is not a rounding manager!");
                }
                nurse.IsRoundingManager = false;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}