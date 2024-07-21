namespace WebApi.Common.Services;
// NOT USED
using FluentValidation;
using System.Reflection;
using Attributes;

[Service<IValidatorType>]
class ValiatorType: IValidatorType
{
    public IValidator? GetValidator(Type model) {
        var modelInterface = typeof(IValidator<>).MakeGenericType(model);
        var validators = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(modelInterface));

        if(validators.Count() == 0) return null;
        return (IValidator?)Activator.CreateInstance(validators.First());
    }

    public Type? GetFromValidator(IValidator validator) {
        return validator.GetType().GetGenericArguments()[0];
    }

    public IValidator[] GetValidators() {
        var validatorType = typeof(IValidator<>);
        var validatorsImplementations = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(validatorType));
        IEnumerable<IValidator> validatorsInstances = validatorsImplementations.Select(v => (IValidator)Activator.CreateInstance(v)!);
        
        return validatorsInstances.ToArray();
    }
}