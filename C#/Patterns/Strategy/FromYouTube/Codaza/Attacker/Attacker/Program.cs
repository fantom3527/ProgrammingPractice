using Attacker.Strategies;
using System;

namespace Attacker
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Squidward");

            hero.Attack();

            Console.WriteLine($"what kind of weapon should I give {hero.GetName()}? \n" +
                              "> B - Broom \n" +
                              "> P - Plunger \n" +
                              "> W - WaterGun");
            switch (Console.ReadLine().ToLower())
            {
                case "b":
                    {
                        hero.SetWeapon(new Broom());
                        break;
                    }
                case "p":
                    {
                        hero.SetWeapon(new Plunger());
                        break;
                    }
                case "w":
                    {
                        hero.SetWeapon(new WaterGun());
                        break;
                    }
            }

            hero.Attack();

            Console.ReadKey();
        }
    }
}
