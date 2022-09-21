namespace Restaurant.Business
{
    using Microsoft.Extensions.DependencyInjection;
    using Restaurant.Business.Interfaces;
    using Restaurant.Business.UseCases;

    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IWaiterService, WaiterService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IBillDetailService, BillDetailService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IDiningTableService, DiningTableService>();

            return services;
        }
    }
}
