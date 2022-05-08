//.NET Core教程 Part2-33：配置系统2 选项方式读取配置
//https://youtu.be/JvvnBHM9doo

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfigurationRoot config = configBuilder.Build();
ServiceCollection services = new ServiceCollection();


services.AddOptions()
	.Configure<DbSettings>(e=>config.GetSection("DB").Bind(e))
	.Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));
services.AddTransient<Demo>();


using (var sp = services.BuildServiceProvider())
{

	while (true)
	{
		//when actually getting data with IOptionsSnapshot which allows to get the data within the scope; data in new scope will be caputured in the new call
		using (var scope = sp.CreateScope())
		{
			var spScope = scope.ServiceProvider;
			var demo = spScope.GetRequiredService<Demo>();
			demo.Test();
		}
		Console.WriteLine("可以改配置啦");
		Console.ReadKey();
	}
}