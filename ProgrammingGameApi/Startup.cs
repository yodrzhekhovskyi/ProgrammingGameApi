using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammingGameApi.Services.Interfaces;
using ProgrammingGameApi.Services.Implementations;
using ProgrammingGameApi.Services.Config;
using FluentValidation;
using FluentValidation.AspNetCore;
using ProgrammingGameApi.Services.PayloadClasses;
using System.Reflection;
using System.IO;
using System;

namespace ProgrammingGameApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Get rextester configuration
            services.Configure<RextesterConfig>(Configuration.GetSection("Rextester"));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => {
                var xmlFiles = new string[]
                {
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml",
                };

                foreach (var file in xmlFiles)
                {
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, file);
                    c.IncludeXmlComments(xmlPath);
                }
            });

            // Add auto mapper
            services.AddAutoMapper(typeof(Startup));

            // Add fluent validation
            services.AddMvc().AddFluentValidation();

            // Add validators
            services.AddTransient<IValidator<SnippetPayload>, SnippetPayloadValidator>();
            services.AddTransient<IValidator<UserPayload>, UserPayloadValidator>();

            // Add services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRiddlesService, RiddlesService>();
            services.AddScoped<ISnippetsService, SnippetsService>();
            services.AddScoped<IStatsService, StatsService>();
            services.AddScoped<IUsersService, UsersService>();
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

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Programming Game Api V0.1");
            });
        }
    }
}
