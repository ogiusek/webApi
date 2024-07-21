namespace WebApi.Common.Services;
// NOT USED
using System.Reflection;

public interface IControllerActionDescriptor
{
    public ParameterInfo[]? GetControllerParameters(HttpContext context);
    public MethodInfo? GetControllerMethod(HttpContext context);
}