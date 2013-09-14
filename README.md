44Con2013Game
=============

The NCC Group Game from 44CON 2013

Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/44Con2013Game

Released under AGPL see LICENSE for more information

Documentation
-------------

The solution is made up of four components:
* WpfQuiz - main game binary
* ScoreWebServer - the score webserver which the ANSi scoreboard consumes 
* QuestionEditor - a GUI tool to write questions for the game
* ANSi Scoreboard - the Raspberry Pi powered scoreboard which consumes the output of ScoreWebServer

Question and Result Storage
-------------
* QuestionEditor will **write** its questions to C:\NCCQuestions
* WpfQuiz will **write** its results to C:\NCCPlayers
* WpfQuiz will **read** its questions relative to binary from .\NCCQuestions
* WpfQuiz will **read** its sounds relative to the binary from .\NCCSounds

Sounds
-------------
If you wish to have sounds play these are the filenames:
* .\\NCCSounds\\Dangerous.wav - when a player requests more time
* .\\NCCSounds\\Secure.wav - when the player requests 50/50
* .\\NCCSounds\\ConfidencePlay.wav - when the player gets to level 8
* .\\NCCSounds\\ExcellentPlay.wav - when the player gets a question right
* .\\NCCSounds\\ShallPlay.wav - when the player that asks for the users name is loaded
* .\\NCCSounds\\Win.wav - when the player completes all the levels
* .\\NCCSounds\\GameOver.wav - when the player gets a question wrong

Deployment Directory Structure 
-------------
So what you end up with is:
* bin\\ - where the program binaries are
* bin\\NCCSounds\\ - where the sounds are
* bin\\NCCQuestions\\ - where the questions are
* C:\\NCCPlayers\\ - where the game stores its played games
* C:\\NCCQuestions\\ - where the **editor** stories its questions

Web Server and the Windows Firewall
-------------
For the ScoreWebServer you need to punch a hole in the firewall with a command similar to:
* netsh http add urlacl url=http://*:8888/ user=everyone

This will allow connections in to port 8888 for the HTTPListener over the network.

Questions
-------------
We haven't released all the questions we wrote. Instead we've left two sample questions in. The application logic looks for questions at the desired level, if it doesn't find any (levels go from 0 to 11) then it uses a question from the previous level.

3rd Party Dependancies 
-------------
For the on-screen touch screen keyboard we use:
* http://wpfkb.codeplex.com/

Putting It All Together
-------------
![ScreenShot](https://raw.github.com/nccgroup/44Con2013Game/master/design/design.png)