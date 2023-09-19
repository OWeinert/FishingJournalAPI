using AutoMapper;
using FishingJournal.API.Authentication;
using FishingJournal.API.Database;
using FishingJournal.API.Mapping;
using FishingJournal.API.Models;
using FishingJournal.API.Services;
using FishingJournal.API.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
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
        public static readonly string DefaultCachePath = $"{Directory.GetCurrentDirectory()}/cache.db";
        public static readonly string[] DefaultHostUrls = new string[] { "https://localhost:7075", "http://localhost:5149" };
        public static readonly string DefaultImagePath = $"{Directory.GetCurrentDirectory()}/images";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register host as systemd service on linux platform
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                builder.Host.UseSystemd();

            var webBuilder = builder.WebHost;

            #region WebHost Builder

            webBuilder.UseKestrel();
            webBuilder.UseIIS();

            var hostUrlsConfig = builder.Configuration.GetValue<string>("HostUrls");
            var hostUrls = !string.IsNullOrWhiteSpace(hostUrlsConfig) ? hostUrlsConfig.Split(";") : DefaultHostUrls;
            webBuilder.UseUrls(hostUrls);

            #endregion WebHost Builder


            var services = builder.Services;

            #region Services Configuration

            services.AddDbContext<FishingJournalDbContext>();

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FishingJournalDbContext>();

            services.AddCors(policyBuilder =>
                policyBuilder.AddDefaultPolicy(policy =>
                    policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyHeader())
            );

            var jwtSettings = builder.Configuration.GetSection("Jwt");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    ValidAudience = jwtSettings.GetSection("Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value))
                };
            });
            services.AddAuthorization(options => { });

            services.AddControllers();
            services.AddEndpointsApiExplorer();

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

            // AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(builder.Configuration));
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // For JwtToken handling
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IJournalEntryService, JournalEntryService>();

            services.AddAntiforgery();

            #endregion Services Configuration


            var app = builder.Build();

            #region App Configuration

            // Swagger WebUI for InDev API testing
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"{ApiTitle} {ApiVersion}"));
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            #endregion App Configuration

            app.Run();
        }
    }
}