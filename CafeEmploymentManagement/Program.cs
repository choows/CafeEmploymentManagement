using Autofac.Extensions.DependencyInjection;
using CafeEmploymentManagement;
using NLog.Web;

public class Program
{

	public static void Main(string[] args)
	{
		var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
		try
		{
			var host = Host.CreateDefaultBuilder(args)
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			})
			.Build();

			host.Run();
		}
		catch (Exception ex)
		{
			logger.Error(ex, "An error occurred");
		}
		finally
		{
			NLog.LogManager.Shutdown();
		}

	}
}