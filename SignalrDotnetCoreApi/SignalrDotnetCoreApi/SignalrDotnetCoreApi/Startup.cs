using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SignalrDotnetCoreApi.Common.Configuration;
using SignalrDotnetCoreApi.Database.Context;
using SignalrDotnetCoreApi.Repository.UnitOfWork;
using SignalrDotnetCoreApi.Service.Services;
using SignalrDotnetCoreApi.Service.SignalRHub;
using Swashbuckle.AspNetCore.SwaggerGen;
using Unity;

namespace SignalrDotnetCoreApi
{
    public class Startup
    {
        private readonly string _origins = "MyOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureSwaggerDocumentation(services);

            services.AddCors(o =>
            {
                o.AddPolicy(_origins,
                    p =>
                    {
                        p.WithOrigins("http://localhost:4200")
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials();
                    });
            });

            services.AddSignalR();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_origins);

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1.1.0/swagger.json", "SignalR .NET core API V1");
                x.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("chatHub");
                endpoints.MapHub<GrapeHub>("/grapeHub");
            });
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            // Could be used to register more types
            container.RegisterType<IConfigurationParser, ConfigurationParser>();
            container.RegisterType<IConfigurationRetriever, ConfigurationRetriever>();
            container.RegisterType<IHubService, HubService>();
            container.RegisterType<IGrapeService, GrapeService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.RegisterType<IDbContext, WineDbContext>(Configuration.GetConnectionString("WineDbConnection"));
        }

        private void ConfigureSwaggerDocumentation(IServiceCollection services)
        {
            services.AddSwaggerGen((SwaggerGenOptions x) =>
            {
                //Swagger Open API Info
                x.SwaggerDoc("v1.1.0", new OpenApiInfo
                {
                    Title = "SignalR .NET core API",
                    Version = "1.1.0",
                    Description = "A SignalR .NET core API Demo",
                    TermsOfService = new Uri("http://www.sunjiangong.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mr SUN Jiangong",
                        Url = new Uri("http://www.sunjiangong.com/"),
                        Email = "contact@sunjiangong.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache License 2.0",
                        Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });

                //Swagger Document Sections
                x.DocumentFilter<SwaggerDocumentFilter>();

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                // Generate XML description file for API routes
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);

                //TODO: review authentication & authorization
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
    }

}
