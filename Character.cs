using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        private string _name;
        protected float _damage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Character()
        {
            _inventory = new Item[10];
            _health = 100;
            _name = "Hero";
            _damage = 10;
        }

        public Character(string nameVal, float healthVal, float damageVal, int inventorySize)
        {
            _inventory = new Item[inventorySize];
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
        }

        public float Attack(Character enemy)
        {
            enemy.TakeDamage(_damage);
            float totalDamage = _damage + _currentWeapon.statBoost;
            return enemy.TakeDamage(totalDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void EquipItem(int itemIndex)
        {
            _damage = _currentWeapon.statBoost;
        }

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        public bool Heal()
        {
            if (_health < 100)
                _health++;

            return true;
        }

        public virtual void Save(StreamWriter writer)
        {
            //Save the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
        }

        public virtual bool Load(StreamReader reader)
        {
            //Create variables to store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            //Checks to see if loading was successful.
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            //If successful, set update the member variables and return true.
            _name = name;
            _damage = damage;
            _health = health;
            return true;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }
    }
}
