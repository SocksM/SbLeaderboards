using Microsoft.OpenApi.Models;
using SbLeaderboards.Api.DAL.Configuration;

namespace SbLeaderboards.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

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

			var app = builder.Build();

			// Configure CORS
			app.UseCors(options => options
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SbLeaderboards.Api v1"));
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
