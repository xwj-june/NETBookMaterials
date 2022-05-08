using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddEnvironmentVariables("TEST_");
IConfigurationRoot configRoot = configBuilder.Build();
string name = configRoot["Name"];
Console.WriteLine(name);

//when passing complex data in environment variable 
//e.g. object in Json
//class "Proxy" - proprty array "Ids"
//To set set first id to be 5 in command lines: 
//Proxy:Ids:1 = 5