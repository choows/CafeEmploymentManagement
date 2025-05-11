using Autofac;
using CafeEmploymentManagement.IoC;
using NLog.Extensions.Logging;

namespace CafeEmploymentManagement
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddCors();

			if (Configuration.GetValue<bool>("SwaggerEnabled"))
			{
				services.AddEndpointsApiExplorer();
				services.AddSwaggerGen();
			}
			if (Configuration.GetValue<bool>("LoggingEnabled"))
			{
				services.AddLogging(loggingBuilder =>
				{
					loggingBuilder.ClearProviders();
					loggingBuilder.AddNLog();
				});
			}
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterInstance<IConfiguration>(Configuration);
			builder.RegisterModule<DatabaseModule>();
			builder.RegisterModule<MediatorModule>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				if (Configuration.GetValue<bool>("SwaggerEnabled"))
				{
					app.UseSwagger();
					app.UseSwaggerUI();
				}
				app.UseCors(builder => builder
				 .AllowAnyOrigin()
				 .AllowAnyMethod()
				 .AllowAnyHeader());
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}