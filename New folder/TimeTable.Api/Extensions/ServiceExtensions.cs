using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TimeTable.Api.Entities.ConfigurationModels;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Interfaces;
using TimeTable.Api.Repositories;
using TimeTable.Api.Service;

namespace TimeTable.Api.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureCors(this IServiceCollection services) =>
		services.AddCors(options =>
		{
			options.AddPolicy("RequireAdmin", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
		});


	public static void ConfigureIISIntegration(this IServiceCollection services) =>
		services.Configure<IISOptions>(options =>
		{
		});


	public static void ConfigureRepositoryManager(this IServiceCollection services) =>
	services.AddScoped<IRepositoryManager, RepositoryManager>();



	public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
		services.AddDbContext<RepositoryContext>(opts =>
			opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

	public static void ConfigureAuthService(this IServiceCollection services) =>
		services.AddScoped<IAuthenticationService, AuthenticationService>();

	public static void ConfigureIdentity(this IServiceCollection services)
	{
		var builder = services.AddIdentity<User, IdentityRole>(o =>
		{
			o.Password.RequireDigit = true;
			o.Password.RequireLowercase = false;
			o.Password.RequireUppercase = false;
			o.Password.RequireNonAlphanumeric = false;
			o.Password.RequiredLength = 4;
			o.User.RequireUniqueEmail = true;
		}).AddEntityFrameworkStores<RepositoryContext>()
		.AddDefaultTokenProviders();
	}

	public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
	{
		var jwtConfiguration = new JwtConfiguration();
		configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

		var secretKey = "MilenaTimeTableApiSecret"; // Environment.GetEnvironmentVariable("SECRET");

		services.AddAuthentication(opt =>
		{
			opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,

				ValidIssuer = jwtConfiguration.ValidIssuer,
				ValidAudience = jwtConfiguration.ValidAudience,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
			};
		});
	}

	public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration) =>
		services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));



}