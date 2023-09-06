using System;
using System.Collections.Generic;
using System.Text;

namespace Attacker.Strategies
{
    class Broom : IWeapon
    {
        void IWeapon.Shoot()
        {
            Console.WriteLine("Attaks Broom Gun");
        }
    }
}
