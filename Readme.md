# Notify

This is a small, containerized discord bot which pings a role when somebody joins a specified voice channel.

## Setup

To set this up, copy the config.example.json into a config.json and modify it or simply start the bot once. 
It will create an empty config for you which you can then modify.

### bot_token
The bot token you got from your discord developer portal.
[Here](https://docs.discordnet.dev/guides/getting_started/first-bot.html) is a nice guide on how to obtain a token. 
Make sure your bot has the correct permissions on the server!
The intents are:
GatewayIntents.Guilds 
GatewayIntents.GuildMembers 
GatewayIntents.GuildVoiceStates

### guild_id
The snowflake ulong id of your server. 
You can get this by enabling developer mode in the discord settings, right-clicking your server icon and select the option "Copy Server ID" 

### voice_channel_ids
An array of voice channel ids you want monitored. You can obtain those in the same way as with the guild id by right-clicking your voice channels.

### notify_role_id 
A role you want pinged. You can get the role id by right-clicking it in the role settings of your guild and selecting "Copy Role ID".

### notify_channel_id
The id of the TEXT CHANNEL you want the notification ping to happen in.