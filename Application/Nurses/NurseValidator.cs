using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Nurses
{
    public class NurseValidator:AbstractValidator<Nurse>
    {
         public NurseValidator()
            {
                RuleFor(x => x.FullName).NotEmpty();
                RuleFor(x => x.Contact).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
            }

    }
}