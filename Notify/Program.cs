using System.Text.Json;
using Discord;
using Discord.WebSocket;
using Notify.Models;
using Notify.Modules;

if (!Directory.Exists("./config"))
	Directory.CreateDirectory("./config");

if (!File.Exists("./config/config.json"))
	await File.WriteAllTextAsync("./config/config.json", ConfigExample.JsonText);

var rawConfig = await File.ReadAllTextAsync("./config/config.json");
var config = JsonSerializer.Deserialize<Config>(rawConfig)!;

var socketConfig = new DiscordSocketConfig()
{
	GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMembers | GatewayIntents.GuildVoiceStates,
};

var client = new DiscordSocketClient(socketConfig);
var notifier = new VoiceChannelNotifier(config, client);

client.Log += Logger.LogEvent;
client.Ready += Initialize;

await client.LoginAsync(TokenType.Bot, config.Token);
await client.StartAsync();

await Task.Delay(-1);
return;

Task Initialize()
{
	client.UserVoiceStateUpdated += notifier.VoiceStatusChanged;
	return Task.CompletedTask;
}