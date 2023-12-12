# Labb2_Threads
School assignment to create an async racing game. Two cars race against each other in two separate threads using tasks.
Both cars also run a "RanIntoTrouble"-method. Every now and then each car (separate of each other) has an event which delays them.

## Structure
The cars are object of the Car class located in the models folder. They are stored in a concurrent dictionary in the Race class.
The Race class handles the setup and ending of the game. It also handles user input during the race through the RaceStatus method.
The user is able to see the status of the race, and can cancel the game. 

The race itself takes place in the Car class via the method DistanceMeter. This method is called on from the RunRace method, which is the method
that handles setup and running of the game.

If one car reaches 10km that car becomes the Winner Car object in the Race properties. The winner is printed to the console.
If the race is cancelled, a "no winner" message is displayed and the game ends. 

The game is started via the property "RaceIsRunning" in the Race class. This ensures that both cars start at the same time. 
Most is controlled via that property or via the cancellation token (also a property of Race).

I originally set some properties and methods up for future expansion, but these have since been removed for a cleaner looking code.