using Microsoft.Extensions.DependencyInjection;


namespace Museum.App.Services.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RepositoryAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }

        public RepositoryAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Lifetime = lifetime;
        }
    }

}
