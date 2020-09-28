using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld
{

    struct Player
    {
        public int health;
        public int damage;
    }

    struct Item
    {
        public int statBoost;
    }

    class Game
    {
        bool _gameOver = false;
        string name = " the player";
        char input = ' ';
        int playerHealth = 100;
        int enemyHealth = 50;
        void RequestName(ref string name)
        {
            
            //Initioalize input value
            char input = ' ';
            //Loop until valid input is given
            while (input != '1')
            {
                //Clear previous text
                Console.Clear();
                //Ask user fro name
                Console.WriteLine("\nPlease enter your name.");
                Console.Write("> ");
                name = Console.ReadLine();
                //Display username
                Console.WriteLine("Hello " + name);
                //Give the user the option to change their name
                Console.WriteLine("Are you sure you want the name " + name + "?");
                input = GetInput("Yes", "No", "Are you sure you want the name " + name + "?");
                if(input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Yeah that's a horrible name. Try again");
                    Console.ReadKey();
                }
                
            }
        }


        void Explore()
        {
            Console.WriteLine("You came to a cross road.");
            input = GetInput("Go Left", "Go right", "You came to a cross road.");
            if(input == '1')
            {
                Console.Clear();
                Console.WriteLine("You decide to go left and a trap is sprung. " +
                    "You're covered up to your chin in quick sand");
                _gameOver = true;
            }
            else if(input == '2')
            {
                Console.Clear();
                Console.WriteLine("You head down the right path and see some structures in the distance.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("After a bit of walking you come across an old town.");
            Console.WriteLine("Once you enter the town a guard approches you.");
            Console.WriteLine("Guard: Excuse me adventurer, we need your help. " +
                "We have a bounty on some bandits south of here. Will you defeat them?");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            input = GetInput("Say yes", "Say no", "Will you accept the bounty?");
            if(input == '1')
            {
                Console.Clear();
                Console.WriteLine("You accept the bounty and trek off to defeat the bandits");
                Console.WriteLine("You find one of the bandits in an abandoned shack.");
                Console.WriteLine("You have entered a fight");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                _gameOver = StartBattle(ref playerHealth, ref enemyHealth);
            }
            else if(input == '2')
            {
                Console.Clear();
                Console.WriteLine("You refuse the bounty.");
                Console.WriteLine("Enraged, the guard puts you in limbo forever");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                while(_gameOver == false)
                {
                    Console.Clear();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }

            }
        }
        void EnterRoom(int roomNumber)
        {
            string exitMessage = "";
            switch (roomNumber)
            {
                case 0:
                    {
                        exitMessage = "You depart from Castle Grayskull";
                        Console.WriteLine("Before you stands the entrance to Castle Grayskull");
                        break;
                        
                    }
                case 1:
                case 2:
                    {
                        exitMessage = "You leave the kitchen";
                        Console.WriteLine("You enter the castle's kitchen there's knives on the ground, rats everywhere, and moldy chicken");
                        break;
                    }

                default:
                    {
                        exitMessage = "You left the hallway";
                        Console.WriteLine("You enter a seemingly never ending hallway");
                        break;
                    }
            }
            if(roomNumber == 0)
            {
                exitMessage = "You depart from Castle Grayskill";
                Console.WriteLine("Before you stands teh entrance to Castle Grayskull");
            }
            else if(roomNumber == 1)
            {
                exitMessage = "You leave the kitchen";
                Console.WriteLine("You Enter the castle's kitchen. There's knives on the ground, rats everywhrere, and moldy chicken");
            }
            else if(roomNumber == 2)
            {
                exitMessage = "You left the hallway";
                Console.WriteLine("You enter a seemingly never ending hallway");
            }
            Console.WriteLine("You are in room " + roomNumber);
            char input = ' ';
            input = GetInput("Go forward", "Go back", "Which direction would you like to go?");
            if(input == '1')
            {
                EnterRoom(roomNumber + 1);
            }
            Console.WriteLine(exitMessage);
        }
        bool StartBattle(ref int playerHealth, ref int enemyHealth)
        {
            //initialize the input variable
            char input = ' ';
            //Creat battle loop. Loops until the player or enemy is dead
            while(playerHealth > 0 && enemyHealth > 0)
            {
                Console.Clear();
                //Get input from player
                input = GetInput("attack", "defend", "What will you do?");
                //If input is 1 then yhe player attacks the enemy
                if(input == '1')
                {
                    enemyHealth -= 20;
                    Console.WriteLine("You attacked and did 20 damage");
                }
                //If input is 2 then teh payer blocked the enemy's attack
                else if(input == '2')
                {
                    Console.WriteLine("You blocked your enemy's attack!");
                    Console.ReadKey();
                    continue;
                }
                playerHealth -= 5;
                Console.WriteLine("The enemy attacked and did 5 damage.");
                Console.ReadKey();
            }
            return playerHealth <= 0;
        }


        void ViewStats()
        {
            //Prints player stats to screen
            Console.WriteLine(name);
            Console.WriteLine("\nPress any key to continue.");
            Console.Write("> ");
            Console.ReadKey();
        }


        char GetInput(string option1, string option2, string query)
        {
            //Initialize input value
            char input = ' ';
            //Loop until a valid input is received
            while(input != '1' && input != '2')
            {
                Console.Clear();
                Console.WriteLine(query);
                //Display options
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. View stats.");
                Console.Write("> ");
                //Get input from user
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                //If the player input 3, call the view stats function
                if(input == '3')
                {
                    ViewStats();
                }
            }
            //retrun input received from user
            return input;
        }

        //Run the game
        public void Run()
        {
            Start();
            while(_gameOver == false)
            {
                Update();
            }
            End();
            
        }

        //Performed once when the game begins
        public void Start()
        {
            Console.WriteLine("Welcome to my game!!!!!!!!!");
            Console.ReadKey();
        }

        //Repeated until the game ends
        public void Update()
        {
            RequestName(ref name);
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThanks for playing!!!!!!!!!!!!");
        }
    }
}
