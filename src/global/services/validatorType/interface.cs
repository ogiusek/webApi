namespace WebApi.Global.Services;
// NOT USED
using FluentValidation;

interface IValidatorType
{
    IValidator? GetValidator(Type model);
    Type? GetFromValidator(IValidator validator);
    IValidator[] GetValidators();
}