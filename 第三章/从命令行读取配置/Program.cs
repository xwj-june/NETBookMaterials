//.NET Core教程 Part2-34：配置系统3 其他配置提供者
//https://youtu.be/GimWVOySY7o
using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddCommandLine(args);
IConfigurationRoot config = configBuilder.Build();
string server = config["server"];
Console.WriteLine($"server:{server}");

//when passing complex data in command lines
//e.g. object in Json
//class "Proxy" - proprty array "Ids"
//To set set first id to be 5 in command lines: 
//Proxy:Ids:1 = 5