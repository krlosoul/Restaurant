namespace Restaurant.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Restaurant.Infrastructure.Mapper;

    public static class Program
    {
        public static void Main()
        {
            AutoMapperConfig.CreateMaps();
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, config) =>
        {
            IConfigurationRoot configurationRoot = config.Build();
        }).ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
