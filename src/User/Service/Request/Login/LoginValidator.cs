using FluentValidation;
using WebApi.Core.ExtensionMethods.String;

namespace WebApi.User.Service.Request;

class LoginValidator : AbstractValidator<Login>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .Must(x => x.IsEmail()).WithMessage("'Email' must be a valid email address.")
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .Length(5, 256)
            .Must(x => x.ContainNumber()).WithMessage("'Password' must contain a number.")
            .Must(x => x.ContainCapitalizedCharacter()).WithMessage("'Password' must contain capitalized character.")
            .Must(x => x.ContainLowerCaseCharacter()).WithMessage("'Password' must contain lower case character.");
    }
}