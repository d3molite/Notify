using Discord;
using Discord.WebSocket;
using Notify.Models;

namespace Notify.Modules;

public class VoiceChannelNotifier(Config config, DiscordSocketClient client)
{
	public async Task VoiceStatusChanged(SocketUser user, SocketVoiceState oldState, SocketVoiceState newState)
	{
		// if the user leaves a channel, or joins a channel which is not monitored
		if (newState.VoiceChannel == null || !IsInMonitored(newState.VoiceChannel.Id))
			return;

		// if something happens in a channel only
		if (oldState.VoiceChannel?.Id == newState.VoiceChannel.Id)
			return;

		// if the user was not in a voice and joins a voice channel
		if (oldState.VoiceChannel is null && IsInMonitored(newState.VoiceChannel.Id))
			await Notify(newState.VoiceChannel.Id, user);
	}

	private async Task Notify(ulong voiceChannelId, SocketUser user)
	{
		var guild = client.GetGuild(config.GuildId);
		var channel = guild.GetTextChannel(config.NotifyChannelId);

		await channel.SendMessageAsync(
			$"<@&{config.NotifyRoleId}>: {user.Username} has joined <#{voiceChannelId}>!",
			allowedMentions: AllowedMentions.All
		);
	}

	private bool IsInMonitored(ulong id)
		=> config.VoiceChannelIds.Contains(id);
}