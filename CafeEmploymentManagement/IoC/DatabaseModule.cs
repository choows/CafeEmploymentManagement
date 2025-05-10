using Autofac;
using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace CafeEmploymentManagement.IoC
{
	public class DatabaseModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{

			builder.Register(c =>
			{
				var configuration = c.Resolve<IConfiguration>();
				var connectionString = configuration.GetConnectionString("Base") ?? throw new NullReferenceException("DB Connection String not configured.");
				var optionsBuilder = new DbContextOptionsBuilder<CafeDbContext>();
				optionsBuilder.UseSqlServer(connectionString);
				return new CafeDbContext(optionsBuilder.Options);
			}).InstancePerLifetimeScope();

			builder.RegisterType<CafeService>().As<ICafeService>();
			builder.RegisterType<EmployeeService>().As<IEmployeeService>();
		}

	}
}
