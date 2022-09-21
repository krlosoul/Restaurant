namespace Restaurant.Api.Configurations
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SwaggerConfiguration
    {
        public SwaggerConfiguration(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("API Restaurant", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API MANAGER Restaurant",
                    Version = "1"
                });
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });
        }
    }
}
