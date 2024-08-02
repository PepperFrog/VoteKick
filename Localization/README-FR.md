[![Release]][Link]
<!----------------------------------------------------------------------------->
[Link]: https://github.com/Antoniofo/VoteKick/releases
<!---------------------------------[ Buttons ]--------------------------------->
[Release]: https://img.shields.io/badge/Release-EFFDE?style=for-the-badge&logoColor=white&logo=DocuSign

# README Traduis

- [**Original** (Anglais)](https://github.com/Antoniofo/VoteKick)

# Installation:

Vous pouvez telecharger ce plugin à partir de ce [.dll](https://github.com/Antoniofo/VoteKick/releases) que vous irez placez ensuite dans ``%AppData%\Roaming\EXILED\Plugins`` (Windows) ou ``~/.config/EXILED/Plugins`` (Linux)

# Comment ca marche ?

VoteKick permet au joueur de créer un votekick contre un joueur s'il est agaçent. Par défaut la durée d'un votekick est de 60 secondes (peut être modifiée). Lorsqu'un votekick est en place, le joueur peut voter pour le kick du joueur, s'il y a suffisamment de votes avant la fin des 60 secondes le joueur est expulsé. Il y a une limite de votekick par tour.

# Commandes

Les commandes peuvent être utilisées dans la console client ou dans la remote admin.

``vk start 4`` - lancez un votekick sur le playerid 4
 
``vk list`` - lister tous les joueurs non-administrateurs avec leur identifiant

``vk vote`` - votez pour le votekick en cours 

Usage: vk <start/list/vote> [playerid]