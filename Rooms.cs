using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

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


        public static void Room1()
        {
            Console.WriteLine("With your guard up and wits about you, you enter the hideout.");
            Console.WriteLine("You walk into a somewhat small space that's lit by wall-mounted torches.");
            Console.WriteLine("After you check your surroundings, you are confronted by a bandit on patrol.");
            Console.WriteLine("Bandit: Hey, you there! You aren't supposed to be here. Leave now or I'll gut ya!");
            
        }

        public static void Room2()
        {
            Console.WriteLine("After your victory you head down into a small, possibly man-made, hallway." +
                "It's well lit with mounted torches. Glad to know you won't need to be a cat person just to see. ¬_¬");
            Console.WriteLine("As you make your way down the hallway you see a guard, asleep in a chair.");
            Console.WriteLine("You do the smart thing and try to sneak past him. Sadly though, sneak isn't a stat cause it's weird." +
                "The guard wakes up and prepares for battle, as should you.");
        }

        public static void Room3()
        {
            Console.WriteLine("You've once again triumphed against your foe. You move on to the next room. This hideout is awefully liniar");
            Console.WriteLine("In the next room you see beds and end tables lined very neatly agains the walls.");
            Console.WriteLine("After searching the room for a bit the only thing you find that is usefull to you is a healing potion, which you promptly drink.");
            Console.WriteLine("You are healed back to full health.");
        }

        public static void Room4()
        {
            Console.WriteLine("After drinking your potion that you ... found... you head off into the next room. Something tells you that this is the last room.");
            Console.WriteLine("As you enter the final room you are greeted by a badit that definitely looks bigger and stronger than all the others you've fought.");
            Console.WriteLine("Boss: How'd you get down here!? Those good for nothing goons! YOU'RE DEAD!!");
        }

    }
}
