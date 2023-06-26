using FishingJournal.API.Authentication;
using FishingJournal.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using System.Runtime.InteropServices;

namespace FishingJournal.API
{
    public class Program
    {
        public const string ApiTitle = "FishingJournalAPI";
        public const string ApiVersion = "v1";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register host as systemd service on linux platform
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                builder.Host.UseSystemd();

            var services = builder.Services;

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"{ApiVersion}", new OpenApiInfo { Title = ApiTitle, Version = ApiVersion });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization using Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJournalEntryService, JournalEntryService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"{ApiTitle} {ApiVersion}"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}