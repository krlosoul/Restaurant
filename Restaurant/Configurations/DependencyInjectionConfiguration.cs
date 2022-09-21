namespace Restaurant.Api.Configurations
{
    using Microsoft.Extensions.DependencyInjection;
    using Restaurant.Business;
    using Restaurant.Infrastructure;

    public class DependencyInjectionConfiguration
    {
        public DependencyInjectionConfiguration(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddBusiness();
        }
    }
}
