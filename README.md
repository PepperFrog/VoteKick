[![Release]][Link]
<!----------------------------------------------------------------------------->
[Link]: https://github.com/Antoniofo/VoteKick/releases
<!---------------------------------[ Buttons ]--------------------------------->
[Release]: https://img.shields.io/badge/Release-EFFDE?style=for-the-badge&logoColor=white&logo=DocuSign


# Installation:

You can install this plugin, download the [.dll](https://github.com/Antoniofo/VoteKick/releases) file and placing it in ``%AppData%\Roaming\EXILED\Plugins`` (Windows) or ``~/.config/EXILED/Plugins`` (Linux)

# How it works

VoteKick lets player create a votekick for a player if he's annoying. by default the duration of a votekick is 60 seconds (can be changed). When a votekick is in place player can vote for the kick of the player, if enough there is enough vote before the end of the 60 seconds the player get kicked. And there is a limit of votekick per round.

# Commands

Commands can be used in the client console or the remoteadmin.

``vk start 4`` - start a votekick on the playerid 4
 
``vk list`` - list all non-admin player with their id

``vk vote`` - vote for the current votekick

Usage: vk <start/list/vote> [playerid]