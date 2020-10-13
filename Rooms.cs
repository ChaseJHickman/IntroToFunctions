using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Rooms
    {
        private Character _character;
        private Item[] _roomItems;

        public Rooms()
        {
            _character = new Character();
            _roomItems = new Item[4];
        }

        public Rooms(Character character, Item[] items)
        {
            _character = character;
            _roomItems = items;
        }

<<<<<<< Updated upstream
        char GetInput(string option1, string option2, string query)
        {
            char input = ' ';
        }

        public void Room1()
=======
        public static void Room1()
        {
            Console.WriteLine("With your guard up and wits about you, you enter the hideout.");
            Console.WriteLine("You walk into a somewhat small space that's lit by wall-mounted torches.");
            Console.WriteLine("After you check your surroundings, you are confronted by a bandit on patrol.");
        }

        public static void Room2()
        {
            
        }

        public static void Room3()
        {

        }

        public static void Room4()
>>>>>>> Stashed changes
        {
            Console.WriteLine("As you enter the hideout, you walk into a small room with a few torches mounted along the walls.");
            Console.WriteLine("While taking in your surroundings, a bandit comes in through a hallway to your left.");
            Console.WriteLine("Bandit: Who are you? Get out, this is our base!");
        }

        public void Room2()
        {
            Console.WriteLine("Once you defeat the bandit, you go down the hallway they entered from.");
            Console.WriteLine("After walking for about a minute or so, you come to another room, fairly similar to the previous one.");
            Console.WriteLine("You see someone against the east wall, but they don't seem hostile.");
            Console.WriteLine("Stranger: Are you here to stop these criminals? If you are, let me help. I'm a healer." +
                "I'm not much for fighting but if needed I can heal you. All I ask is that you escort me out of here.");

        }
    }
}
