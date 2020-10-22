# One Bounty Wonder

## Game.cs
+ InitializeTimes: Sets each weapons names and damage values

+ CreateCharacter: This function "creates" the player's character
	* In the console it will ask the player what their name is
	* The player's name is saved as a string
	* The player character then has their values for their name, health, damage, and inventory initialized
	* The "SelectItem" function is called
	* The "EquipItem" function is called
	* The function returns what "player" is

+ SelectItem: This function presents the player with 5 weaopon options
	* An overloaded "GetInput" function is called presenting the names of each weapon and prompting the player to choose one
	* An if statement takes in the player's input (1-5) and picks the appropriate weapon

+ Save: This function is meant to save the player characters current stats for later use (this function is never called due to errors and time constraints)
	* A streamwriter is called and makes a new txt file
	* The player character's stats are saved on the txt file
	* The streamwriter closes

+ Load: This function is meant to load a previous player character's stats that where saved (this function is never called for the same reasons as save)
	* A streamreader is called to read the txt file with save data that was written previously
	* The player character's stats are then loaded and called into the game
	* The streamreader closes

+ Explore: This function is essentially the entire game
	* The console writes "You came to a cross road."
	* An overloaded "GetInput" function is called
		* The function asks the player for it's input which will determine the outcome through an if statement'
	* If the player's input = 1
		* The console clears and displays the outcome of the player
		* The game ends
	* If the player's inoput = 2
		* the console clears and displays the outcome of the player
		* The player must provide input to continue
	* The player is then presented with a choice to either take a bounty or not
	* if the player declines the guard will trap the player in limbo forever, ending the game
	* if the player accepts they will continue the game
	* the player is presented with the first enemy encounter
	
	* The Rooms.Room1 function is called
	* The start battle function is called

	* The Rooms.Room2 function is called
	* The start battle function is called

	* the Rooms.Room3 function is called
	* the Player heal function is called

	* The Rooms.Room4 function is called
	* The start battle function is called

	* The console presents the player with text showing the end of the game

+ StartBattle: This function handles combat and takes in 2 Characters as the parameters
	* A while loop stating that while fighter1.GetIsAlive & fighter2.GetIsAlive are both true then
		* The console will clear and ask the player if they will attack or defend
		* if the player attacks then 
			* The player will deal their weapons damage to the enemy
		* if the player defends then
			* The console will display to the player that defending isn't a mechanic
	* At the end of the loop the enemy will deal a set amount of damage to the player
	* once the loop is exited the function returns fighter1.GetIsAlive to be true

+ GetInput: This function takes in player input
	* The console will present the player with specific options set by the program for the specific scenario they are in.
	* the input "1" is set to the first option
	* the input "2" is set to the second option
	* the input "3" is set to call the "PrintStats" function

	* the function returns the player's input

+ GetInput: This function takes in the player input
	* This is an overloaded function that does the same thing as the first one except input "3" is set to the third option instead of printstats

+ Run: This function Starts the game
	* The "Start" functin is called
	* While "_gameOver" is returning false then loop the "Update" function
	* after the while loop the "End" function is called

+ Start: This function is the beginning of the game
	* The Console welcomes the player and waits for any input
	* _player1 is set to the "CreateCharacter" function
	* The "InitializeEnemies" function is called

+ Update: This function  I S  the game
	* The "Explore" function is called
	* The "End" function is called

+ End: This function is the end of the game
	* The console thanks the player for playing the game.


## Character.cs

+ Character: this function initializes character stats
	* inventory is initialized
	* health is initialized
	* name is initialized
	* damage is initialized

+ Character: Not sure exactly what this function is for but here is what is passed through it
	* _inventory = new Item[inventorySize]
	* _health = healthVal
	* _name = nameVal
	* _damage = damageVal

+ Attack: This function defines what attacking is
	* takes in parameter called "enemy"
	* calls "TakeDamage" function
	* sets 'totalDamage' to _damage + _currentWeapon.statBoost
	* returns the damage "enemy" took

+ PrintStats: This prints the players stats
	* The console writes the players current name, health, and damage values

+ AddItemToInventory: This function makes every value in the "inventory" array classify as an Item (i think idk)
	* _inventory[index] = item;

+ GetInventory: This function returns the player's inventory
	* return _inventory

+ EquipItem: This function initializes the weapon picked by the player
	* _damage = _currentWeapon.statBoost

+ UnequipItem: This function uninitializes the weapon picked by the player
	* _currentWeaopn = _hands

+ TakeDamage: This function calculates damage taken
	* _health -= damageVal
	* if(_health < 0)
		* _health = 0
	*return damageVal

+ Heal: This function heals the player
	* if (_health < 100)
		* _health++
	* return ture

+ Save: This function is meant to save the player characters current stats for later use (this function is never called due to errors and time constraints)
	* A streamwriter is called and makes a new txt file
	* The player character's stats are saved on the txt file
	* The streamwriter closes

+ Load: This function is meant to load a previous player character's stats that where saved (this function is never called for the same reasons as save)
	* A streamreader is called to read the txt file with save data that was written previously
	* The player character's stats are then loaded and called into the game
	* The streamreader closes

+ GetName: this function returns the players name
	* return _name

+ GetIsAlive: Chacks to see if the characeter is alive
	* return _health > 0


## Rooms.cs

+ Room1: This function describes the first room
	* the console prints the details of the player entering the first room and encountering a bandit

+ Room2: This function describes the second room
	* the console prints the details of the player entering the second room and encountering another bandit

+ Room3: This function describes the third room
	* the console prints the details of the player entering the third room and finding a healing potion

+ Room4: this function describes the fourth room
	* the console prints the details of the player entering the fouth and final room and encountering the boss bandit