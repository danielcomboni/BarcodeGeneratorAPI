using BarcodeGeneratorAPI.Core.Extensions ;
using Microsoft.AspNetCore.Builder ;
using Microsoft.AspNetCore.Hosting ;
using Microsoft.Extensions.Configuration ;
using Microsoft.Extensions.DependencyInjection ;
using Microsoft.Extensions.Hosting ;

namespace BarcodeGeneratorAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServicesConfiguration(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080", "https://danielcomboni.github.io", "http://localhost:8081", "https://localhost:44397/", "https://localhost:44382", "https://localhost:44377", "https://localhost:44310", "https://pdf417viewer.herokuapp.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApiExceptionHandler();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barcode Generator API V1");
            });

            app.UseFileServer();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
