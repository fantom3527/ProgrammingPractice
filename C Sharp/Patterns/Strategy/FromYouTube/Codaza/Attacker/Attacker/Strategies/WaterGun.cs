using System;

namespace Attacker.Strategies
{
    class WaterGun : IWeapon
    {
        void IWeapon.Shoot()
        {
            Console.WriteLine("Attaks Water Gun");
        }
    }
}
