namespace Restaurant.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using Restaurant.Infrastructure.DataAccess;
    using Restaurant.Infrastructure.Interfaces;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
