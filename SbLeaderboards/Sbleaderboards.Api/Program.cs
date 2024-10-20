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

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowLocal",
					policy =>
					{
						policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
							  .AllowAnyMethod()
							  .AllowAnyHeader();
					});
			});

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
#warning Didn't setup CORS yet for deployment
				app.UseCors();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
