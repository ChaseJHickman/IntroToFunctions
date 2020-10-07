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

        public void Room1()
        {

        }
    }
}
