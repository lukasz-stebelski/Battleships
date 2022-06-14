# Battleships

Solution consists of 3 projects:

1. Battleships.BL - game logic.
2. Battleships.UI - presentation of game progress - console based.
3. Battleships.Test - simple unit tests covering some logic points.

In order to run the game start the console app. 

Project is NET 6 based, uses Moq as external NuGet package which requires restoration.

Game shows randomized chosen board to start with. 
For the need of evaluation one might need to remember that as this will be cleared. 
