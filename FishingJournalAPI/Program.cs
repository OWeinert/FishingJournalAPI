using AutoMapper;
using FishingJournal.API.Authentication;
using FishingJournal.API.Database;
using FishingJournal.API.Helpers;
using FishingJournal.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NeoSmart.Caching.Sqlite;
using System.Runtime.InteropServices;
using System.Text;

namespace FishingJournal.API
{
    public class Program
    {
        public const string ApiTitle = "FishingJournalAPI";
        public const string ApiVersion = "v1";

        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var builder = WebApplication.CreateBuilder(args);

            // Register host as systemd service on linux platform
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                builder.Host.UseSystemd();

            var services = builder.Services;

            services.AddDbContext<FishingJournalDbContext>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSqliteCache(options =>
            {
                var configPath = builder.Configuration.GetValue<string>("Jwt:TokenCachePath")!;
                options.CachePath = !string.IsNullOrWhiteSpace(configPath) ? configPath : Directory.GetCurrentDirectory();
            });

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"{ApiVersion}", new OpenApiInfo { Title = ApiTitle, Version = ApiVersion });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    Description = "Please enter valid token",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthResponsesOperationFilter>();
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddSingleton(mapper);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<TokenServiceMiddleware>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJournalEntryService, JournalEntryService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"{ApiTitle} {ApiVersion}"));
            }

            app.UseMiddleware<TokenServiceMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}