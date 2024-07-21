namespace WebApi.Global.Attributes;

using System.Reflection;

public enum ServiceLifetime{
    Singleton,
    Scoped,
    Transient
}

public interface IServiceBase {
    public ServiceLifetime Lifetime { get; set; }
};

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class Service : Attribute, IServiceBase {
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Singleton;
};

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class Service<TInterface> : Attribute, IServiceBase {
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Singleton;
}

static class ServiceLoader{
    public static IServiceCollection Addservices(this IServiceCollection services){
        Console.WriteLine("Loading services");
        AddServicesWithoutInterfaces(services);
        AddServicesWithInterfaces(services);
        return services;
    }

    public static void AddServicesWithInterfaces(IServiceCollection services){
        List<Type> serviceTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute(typeof(Service<>)) != null)
            .ToList();

        serviceTypes.ForEach(service => {
            Type interfaceType = service.GetCustomAttribute(typeof(Service<>))!.GetType().GetGenericArguments()[0];
            ServiceLifetime? lifetime = (service.GetCustomAttribute(typeof(Service<>)) as IServiceBase)!.Lifetime;
            switch (lifetime) {
                case ServiceLifetime.Singleton: services.AddSingleton(interfaceType, service);
                    break;
                case ServiceLifetime.Scoped:    services.AddScoped(interfaceType, service);
                    break;
                case ServiceLifetime.Transient: services.AddTransient(interfaceType, service);
                    break;
            }
        });
    }

    private static void AddServicesWithoutInterfaces(IServiceCollection services){
        List<Type> serviceTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<Service>() != null)
            .ToList();

        serviceTypes.ForEach(service => {
            ServiceLifetime lifetime = (service.GetCustomAttribute<Service>() as IServiceBase)!.Lifetime;
            switch (lifetime) {
                case ServiceLifetime.Singleton: services.AddSingleton(service);
                    break;
                case ServiceLifetime.Scoped: services.AddScoped(service);
                    break;
                case ServiceLifetime.Transient: services.AddTransient(service);
                    break;
            }
        });
    }
}