using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        bool _gameOver = false;
        string _playerName = "";
        char input = ' ';
        void RequestName()
        {
            //If player already has a name, return from function
            if(_playerName != "")
            {
                return;
            }
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
                _playerName = Console.ReadLine();
                //Display username
                Console.WriteLine("Hello " + _playerName);
                //Give the user the option to change their name
                Console.WriteLine("Are you sure you want the name " + _playerName + "?");
                input = GetInput("Yes", "No", "Are you sure you want the name " + _playerName + "?");
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
            input = GetInput("Say yes", "Say no",);
            if(input == '1')
            {
                Console.Clear();
            }

        }


        void ViewStats()
        {
            //Prints player stats to screen
            Console.WriteLine(_playerName);
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
            RequestName();
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThanks for playing!!!!!!!!!!!!");
        }
    }
}
