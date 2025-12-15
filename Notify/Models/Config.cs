using System.Text.Json.Serialization;

namespace Notify.Models;

public class Config
{
	[JsonPropertyName("bot_token")]
	public required string Token { get; set; }
	
	[JsonPropertyName("guild_id")]
	public ulong GuildId { get; set; }
	
	[JsonPropertyName("voice_channel_ids")]
	public IEnumerable<ulong> VoiceChannelIds { get; set; }
	
	[JsonPropertyName("notify_role_id")]
	public ulong NotifyRoleId { get; set; }
	
	[JsonPropertyName("notify_channel_id")]
	public ulong NotifyChannelId { get; set; }
}