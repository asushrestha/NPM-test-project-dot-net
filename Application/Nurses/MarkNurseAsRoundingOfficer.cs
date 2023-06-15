using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Nurses
{
    public class MarkNurseAsRoundingOfficer
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var nurse = await _context.Nurses.FindAsync(request.Id);
                if(nurse.IsRoundingManager){
                    throw new Exception("Nurse is already a rounding manager!");
                }
                nurse.IsRoundingManager = true;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}