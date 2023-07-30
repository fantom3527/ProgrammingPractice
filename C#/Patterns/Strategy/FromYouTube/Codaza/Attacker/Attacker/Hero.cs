using Attacker.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attacker
{
    class Hero
    {
        private readonly string _name;
        private IWeapon _weapon;

        public string GetName() => _name;
        public Hero(string name)
        {
            _name = name;
        } 

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Attack()
        {
            Console.WriteLine(">>>");

            if (_weapon is null)
            {
                Console.WriteLine($"{_name} can't attack. Set a weapon.");
                return;
            }

            Console.WriteLine($"{_name} stands menacingly");
            Console.WriteLine($"{_name}");
            _weapon.Shoot();
            Console.WriteLine($"{_name} ceases to stand menacingly");
        }
    }
}
