using System;
using System.Collections.Generic;
using System.Text;

namespace Attacker.Strategies
{
    class Plunger : IWeapon
    {
        void IWeapon.Shoot()
        {
            Console.WriteLine("Attaks Plunger Gun");
        }
    }
}
