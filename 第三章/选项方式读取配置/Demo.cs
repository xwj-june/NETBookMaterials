using Microsoft.Extensions.Options;

class Demo
{
	private readonly IOptionsSnapshot<DbSettings> optDbSettings;
	private readonly IOptionsSnapshot<SmtpSettings> optSmtpSettings;
	public Demo(IOptionsSnapshot<DbSettings> optDbSettings,
		IOptionsSnapshot<SmtpSettings> optSmtpSettings)
	{
		//note: get IOptionsSnapshot rather than get the value directly, so to it can help with reload data if change exists
		this.optDbSettings = optDbSettings;
		this.optSmtpSettings = optSmtpSettings;
	}
	public void Test()
	{
		var db = optDbSettings.Value;
		Console.WriteLine($"数据库：{db.DbType},{db.ConnectionString}");
		var smtp = optSmtpSettings.Value;
		Console.WriteLine($"Smtp：{smtp.Server},{smtp.UserName},{smtp.Password}");
	}
}