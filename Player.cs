using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentWeapon;

        public Player() : base()
        {
            _inventory = new Item[3];
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
            : base(healthVal, nameVal, damageVal)
        {
            _inventory = new Item[inventorySize];
        }

        public void EquipItem(int itemIndex)
        {
            _damage = _inventory[itemIndex].statBoost;
        }

        

        public override float Attack(Character enemy)
        {
            enemy.TakeDamage(_damage);
            float totalDamage = _damage + _currentWeapon.statBoost;
            return enemy.TakeDamage(totalDamage);
        }
    }
}
