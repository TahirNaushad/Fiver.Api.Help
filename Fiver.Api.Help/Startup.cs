using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Fiver.Api.Help
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("help", new Info
                {
                    Title = "Fiver.Api Help",
                    Version = "v1"
                });

                var xmlDocPath = PlatformServices.Default.Application.ApplicationBasePath;
                options.IncludeXmlComments(Path.Combine(xmlDocPath, "Fiver.Api.Help.xml"));
            });

            services.AddMvc();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/help/swagger.json", "Fiver.Api Help Endpoint");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
