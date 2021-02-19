using CachingWebApp.Data;
using CachingWebApp.Service;
using CachingWebApp.Service.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace CachingWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ILocationService, LocationService>();
            services.AddScoped<ICacheBase, CacheBase>();
            services.AddScoped<ILocationCachingService, LocationCachingService>();

            string connecitonString = Configuration.GetConnectionString("LocationDbContext");
            services.AddDbContext<LocationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocationDbContext")));

            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Caching Location API",
                    Description = "Caching web service net core API Document",
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");
                options.RoutePrefix = "api-docs";
                options.DocumentTitle = "Caching web app API Document";
                options.DocExpansion(DocExpansion.List);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}