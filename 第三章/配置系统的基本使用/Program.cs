//.NET6教程 Part2-32：配置系统1 入门
//https://youtu.be/pv8J0zBKCKg

using Microsoft.Extensions.Configuration;

//手动读取配置
ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);
IConfigurationRoot config = configBuilder.Build();
string name = config["name"];
Console.WriteLine($"name={name}");
string proxyAddress = config.GetSection("proxy:address").Value;
Console.WriteLine($"Address:{proxyAddress}");

//Binding configuration data into class
//NuGet package: Microsoft.Extensions.Configuration.Binder
var proxy = config.GetSection("proxy").Get<Proxy>();
Console.WriteLine(proxy.Address);
Config config = configRoot.Get<Config>();
Console.WriteLine(config.Name);

class Config{
    public string Name {get; set;}
    public int Age {get; set;}
    public Proxy Proxy {get; set;}
}

class Proxy{
    public string Address {get; set;}
    public string Port {get; set;}
}
