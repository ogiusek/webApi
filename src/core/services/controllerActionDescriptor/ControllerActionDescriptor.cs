namespace WebApi.Core.Services;
// NOT USED
using System.Reflection;
using Attributes;

[Service<IControllerActionDescriptor>]
public class ControllerActionDescriptor : IControllerActionDescriptor{

    public ParameterInfo[]? GetControllerParameters(HttpContext context){
        var method = GetControllerMethod(context);
        return method?.GetParameters();
    }

    public MethodInfo? GetControllerMethod(HttpContext context){
        (string? className, string? functionName) = GetControllerClassAndFunctionName(context);
        if(className == null || functionName == null) return null;

        var classType = Type.GetType(className);
        var method = classType?.GetMethod(functionName);
        return method;
    }

    private (string?, string?) GetControllerClassAndFunctionName(HttpContext context){
        string endpointFunction = context.GetEndpoint()?.ToString()?.Split(" ")[0]??"";
        IEnumerable<string> split = endpointFunction.Split(".");
        string? className = string.Join(".", split.SkipLast(1));
        string? functionName = split.Last();
        return (className, functionName);
    }
}