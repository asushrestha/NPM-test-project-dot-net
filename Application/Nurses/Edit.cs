using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Nurses
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Nurse Nurse { get; set; }
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
                var nurse = await _context.Nurses.FindAsync(request.Nurse.Id);
                nurse.FullName= request.Nurse.FullName?? nurse.FullName;
                nurse.Email = request.Nurse.Email?? nurse.Email;
                nurse.Contact = request.Nurse.Contact?? nurse.Contact;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }   
        }
    }
}