using FluentValidation;
using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Validation
{
    public class PlayerValidation : AbstractValidator<Player>
    {
        public PlayerValidation()
        {
            RuleFor(player => player.Surname).Length(2, 50).WithMessage("Surname is incorect");
            RuleFor(player => player.Name).Length(2, 20).WithMessage("First is incorect");
            RuleFor(player => player.Email).EmailAddress();
        }
    }
}
