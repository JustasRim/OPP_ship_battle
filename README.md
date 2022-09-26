BattleShip
===========
Network game based on Battleship in the client-server architecture

Description
-----------
**BattleShip** is a simple network game using sockets, TCP protocol and the client-sever architecture. Available in the English language version. Designed for using in the local network. Gameplay between 2 
synchronous players via an asynchronous server.

Project consists of 2 modules: 
- console server application that receives and sends messages in asynchronous mode and mediates between clients,
- windows forms client application that receives and sends messages in synchronous mode and supports logic of game.

Library, technologies, tools
----------------------------
- C#,
- .NET framework 4.5.2,
- WFA,
- Microsoft Visual Studio Enterprise 2017.

Selected application windows
----------------------------
<p align="center"><img src="https://github.com/gradzka/BattleShip/blob/master/Screenshots/Server.png"></p>
<p align="center"><em>Figure 1. Server window</em></p>

<p align="center"><img src="https://github.com/gradzka/BattleShip/blob/master/Screenshots/Connection.png"></p>
<p align="center"><em>Figure 2. Connection window</em></p>

<p align="center"><img src="https://github.com/gradzka/BattleShip/blob/master/Screenshots/SearchEnemy.png"></p>
<p align="center"><em>Figure 3. The enemy search window</em></p>

<p align="center"><img src="https://github.com/gradzka/BattleShip/blob/master/Screenshots/Setting.png"></p>
<p align="center"><em>Figure 4. Ships setting window</em></p>

<p align="center"><img src="https://github.com/gradzka/BattleShip/blob/master/Screenshots/Game.png"></p>
<p align="center"><em>Figure 5. Game window</em></p>

TODO
----
Project requires several improvements:
- securing the loss of connection between clients and server,
- encryption of communication between clients and server,
- coding/decoding of sent/received messages.

How to run
----------
- run BattleShipServer.exe
- run BattleShipClient.exe

Attributions
------------
- https://msdn.microsoft.com/pl-pl/library/fx6588te(v=vs.110).aspx,
- https://msdn.microsoft.com/en-us/library/kb5kfec7(v=vs.85).aspx,
- https://pixabay.com/pl/.

Thanks for https://github.com/kazimierczak-robert/ for idea and help with unblocking the application GUI :)
