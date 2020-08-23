using Api.Models.Dtos;
using FluentValidation;

namespace Api.Models.Validators
{
    public class CharacterValidator : AbstractValidator<CharacterDto>
    {
        public CharacterValidator()
        {
            RuleFor(n => n.Name).NotEmpty();
            RuleFor(n => n.Role).NotEmpty();
            RuleFor(n => n.School).NotEmpty();
            RuleFor(n => n.HouseId).NotEmpty();
            RuleFor(n => n.Patronus).NotEmpty();
        }
    }
}
