using Discord;

namespace Notify.Modules;

public static class Logger
{
	public static async Task LogEvent(LogMessage arg)
	{
		Console.WriteLine(arg.ToString());
	}
}