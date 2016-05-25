using FluentValidation;
using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Validation
{
    public class VenueValidation : AbstractValidator<Venue>
    {
        public VenueValidation()
        {
            RuleFor(venue => venue.Address).NotNull().Length(10, 150).WithMessage("Write an address");
            RuleFor(venue => venue.Name).NotNull().Length(5, 50);
            RuleFor(venue => venue.Descrition).NotNull().Length(5, 50);
            //RuleFor(venue => venue.Hour).GreaterThan(0).LessThan(23);
            //RuleFor(venue => venue.Minute).GreaterThan(0).LessThan(59);
            RuleFor(venue => venue.Day).NotNull();
        }
    }
}
