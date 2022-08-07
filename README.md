# TwitchRaid

Twitch Raiding is a programm that automatically calls the Twitch API and searches through your Followers. After that it will call every Follower of yours if 
that Person is Live. Then the Streamer will be in a List of People that will get randomly selected. The Stream that got selected will be Raided with a 
chat "/Raid" commande in the Twitch Chat.

Importened Stoff you need to set up:

  Go on the Twitch Dev website and set up a API 
  https://dev.twitch.tv/
  On the Top right there is A Button "Console" Click on it and register A Application to localhost and with a name.
  
  By First Time Starting the progamm it will generat a Passwort.txt with lines that need to be filled in outherwise the Application will not work.
  Fill in the Stoff you get from Twitch.
  
        ClientID: xxx
        ClientSecret: xxx
        oauth: xxx
        Chatroom: xxx
        BotName: xxx
        ID: xxx

ClientID and ClientSecret will you get when you make the Application for Twitch

oauther is something i only got by going to this link to generate me the oauther
https://twitchapps.com/tmi/
Past it fully like "oauth: oauth:xxx"

Chatroom is the Twitch Chat you want to join should be yours or maybe you want to Raid via the Editor Status from a other Streamer that is not you.

BotName is the Account that will send the Message I selected my Own Account for it. Your Twitchname


If you did all that you can Happy raid people with just One Click :3
