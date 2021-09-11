using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Razor.Interfaces;
using Razor.Models;
using Razor.Repository;
using Razor.ValidationFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<TodoContext>(opt =>
            //opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();
            var confg = Configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(confg));
            services.AddSwaggerGen();
            services.AddScoped<ITaxPayerRepository, TaxPayerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddMvc(
             options =>
             {
                 options.Filters.Add(typeof(ModelValidationFilter));
             });
            services.AddControllersWithViews();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddLogging();

            // Additional code to register the ILogger as a ILogger<T> where T is the Startup class
            services.AddSingleton(typeof(ILogger), typeof(Logger<Startup>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
            });
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
