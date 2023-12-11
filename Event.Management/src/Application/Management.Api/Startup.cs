using Management.Api.Entities.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Management.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //var appSettingsSection = _configuration.GetSection("Configurations:AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);
            //services.AddSingleton(_ => appSettingsSection.Get<AppSettings>());
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configurations/appsettings.json", optional: true, reloadOnChange: true);

            var configuration = configBuilder.Build();

            // Register the configuration
            services.AddSingleton(configuration);


            services.AddLogging();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Management API", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}