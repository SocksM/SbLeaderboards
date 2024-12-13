using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Api.DAL.Context;

namespace SbLeaderboards.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			//
			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "SbLeaderboards.Api", Version = "v1" });
			});

			// Add configuration setup
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			builder.Services.AddSingleton(configuration);
			builder.Services.AddSingleton<AppConfiguration>();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("ANY",
					policy =>
					{
						policy.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
				options.AddPolicy("AllowLocal",
					policy =>
					{
						policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
							  .WithMethods("GET")
							  .AllowAnyHeader();
					});
				options.AddPolicy("Production",
					policy =>
					{
						policy.AllowAnyOrigin()
							.WithMethods("GET")
							.AllowAnyHeader();
					});
			});

			string connString;
			if (builder.Environment.IsDevelopment())
			{
				connString = builder.Configuration.GetConnectionString("DevConnection");
			}
			else
			{
				connString = builder.Configuration.GetConnectionString("ProductionConnection");
			}
			builder.Services.AddDbContext<SbLeaderboardsContext>(options =>
					options.UseMySql(connString, ServerVersion.AutoDetect(connString)));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SbLeaderboards.Api v1"));

				// Configure CORS
				app.UseCors("AllowLocal");
			}
			else
			{
				// Configure CORS
				app.UseCors("Production");
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}