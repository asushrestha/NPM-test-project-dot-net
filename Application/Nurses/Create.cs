using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Nurses
{
    public class Create
    {
        public class Command : IRequest
        {
            public Nurse Nurse { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Nurse).SetValidator(new NurseValidator());
            }

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
                var nurse = _context.Nurses.Any(x => x.Email ==request.Nurse.Email);
                if(nurse){
                    throw new Exception("Nurse with this email already exists!");
                }
                _context.Nurses.Add(request.Nurse);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}