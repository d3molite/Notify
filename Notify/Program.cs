using System.Text.Json;
using Discord;
using Discord.WebSocket;
using Notify.Models;
using Notify.Modules;

var rawConfig = await File.ReadAllTextAsync("./config/config.json");
var config = JsonSerializer.Deserialize<Config>(rawConfig);


var socketConfig = new DiscordSocketConfig()
{
	GatewayIntents = GatewayIntents.Guilds,
};

var client = new DiscordSocketClient(socketConfig);

client.Log += Logger.LogEvent;

await client.LoginAsync(TokenType.Bot, config!.Token);
await client.StartAsync();

await Task.Delay(-1);