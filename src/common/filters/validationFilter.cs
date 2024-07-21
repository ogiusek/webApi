namespace WebApi.Common.Filters;

using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Attributes;

[Filter]
public class ValidationFilter : IActionFilter
{
    private static IEnumerable<Type>? validators = null;
    private static IEnumerable<Type> GetValidators(){
        if(validators != null)
            return validators;
        validators = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Where(i => i.FullName == "FluentValidation.IValidator").Count() != 0);
        return validators!;
    }

    private Type? GetValidatorType(Type? type){
        if(type == null) return null;
        // List<Type> validators = Assembly
        //     .GetExecutingAssembly()
        //     .GetTypes()
        List<Type> validators = GetValidators()
            .Where(t => t.GetInterfaces().Contains(typeof(IValidator<>).MakeGenericType(type)))
            .ToList();
        if(validators.Count == 0) return null;
        return validators.First();
    }

    private FluentValidation.Results.ValidationResult? RunValidation(Type? validatorType, object? value){
        if(value == null || validatorType == null) return null;
        var validator = Activator.CreateInstance(validatorType);
        MethodInfo? validatorMethod = typeof(IValidator<>).MakeGenericType(value.GetType()).GetMethod("Validate");
        FluentValidation.Results.ValidationResult? validated = validatorMethod!.Invoke(validator, new object[]{value}) as FluentValidation.Results.ValidationResult;
        return validated;
    }

    // Do something before the action executes.
    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach(var arg in context.ActionArguments){
            object? value = arg.Value;
            if(value == null) continue;

            Type? validatorType = GetValidatorType(value?.GetType());
            if(validatorType == null) continue;

            var validated = RunValidation(validatorType, value);
            if(validated?.IsValid != false) continue;

            context.Result = new BadRequestObjectResult(validated.ToString());
            return;
        }
    }

    // Do something after the action executes.
    public void OnActionExecuted(ActionExecutedContext context) {}
}