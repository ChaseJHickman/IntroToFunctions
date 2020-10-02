﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld
{


    struct Item
    {
        public string name;
        public int statBoost;
    }

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Enemy _enemy1;
        private Enemy _enemy2;
        private Enemy _enemy3;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _wand;
        private Item _mace;
        char input = ' ';



        public void InitializeItems()
        {
            _longSword.name = "Longsword";
            _longSword.statBoost = 15;
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _bow.name = "Bow";
            _bow.statBoost = 14;
            _wand.name = "Wand";
            _wand.statBoost = 18;
            _mace.name = "Mace";
            _mace.statBoost = 22;
        }

        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10,5);
            SelectItem(player);
            return player;
        }

        public void InitializeEnemies()
        {
            _enemy1 = new Enemy("Bandit", 100, 10, 5);
            _enemy2 = new Enemy("Bandit", 100, 10, 5);
            _enemy3 = new Enemy("Bandit", 100, 10, 5);
        }

        public void SelectItem(Player player)
        {
            char input;
            GetInput(out input, "Longsword", "Dagger", "Welcome! Please choose a weapon.");
            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_dagger, 0);
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
                StartBattle(_player1, _enemy1);
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
        bool StartBattle(Character fighter1, Character fighter2)
        {
            //initialize the input variable
            char input = ' ';
            //Creat battle loop. Loops until the player or enemy is dead
            while(fighter1.GetIsAlive()  && fighter2.GetIsAlive())
            {
                Console.Clear();
                //Get input from player
                input = GetInput("attack", "defend", "What will you do?");
                //If input is 1 then yhe player attacks the enemy
                if(input == '1')
                {
                    float damageTaken = 0;
                    damageTaken = fighter1.Attack(fighter2);
                    Console.WriteLine("You attacked and did " + damageTaken + " !");
                }
                //If input is 2 then teh payer blocked the enemy's attack
                else if(input == '2')
                {
                    Console.WriteLine("You blocked your enemy's attack!");
                    Console.ReadKey();
                    continue;
                }
                float damageRecieved = 0;
                damageRecieved = fighter2.Attack(fighter1);
                Console.WriteLine(fighter2.GetName() + "attacked and did " + damageRecieved + " !");
                Console.ReadKey();
            }
            return fighter1.GetIsAlive();
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
                    _player1.PrintStats();
                }
            }
            //retrun input received from user
            return input;
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
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
            _player1 = CreateCharacter();
            InitializeEnemies();
        }

        //Repeated until the game ends
        public void Update()
        {
            
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThanks for playing!!!!!!!!!!!!");
        }
    }
}
