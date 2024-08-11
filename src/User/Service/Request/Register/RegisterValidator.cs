using FluentValidation;
using WebApi.Core.ExtensionMethods.String;

namespace WebApi.User.Service.Request;

class RegisterValidator : AbstractValidator<Register>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email)
            .Must(x => x.IsEmail()).WithMessage("'Email' must be a valid email address.")
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .Length(5, 256)
            .Must(x => x.ContainNumber()).WithMessage("'Password' must contain a number.")
            .Must(x => x.ContainCapitalizedCharacter()).WithMessage("'Password' must contain capitalized character.")
            .Must(x => x.ContainLowerCaseCharacter()).WithMessage("'Password' must contain lower case character.");

        RuleFor(x => x.Name)
            .Length(2, 32)
            .Must(x => x.IsName()).WithMessage("'Name' must contain only letters.");

        RuleFor(x => x.Surname)
            .Length(2, 32)
            .Must(x => x.IsSurname()).WithMessage("'Surname' must contain only letters, dash and space.");
    }
}