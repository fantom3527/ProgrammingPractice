using Codaza.Domain;
using Codaza.Factories;
using System;

namespace Codaza
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(">>> WELCOME TO FITNESSCLUB <<<\n");
            Console.WriteLine("> Enter the membership type you would like to create: <" +
                              "\n > G - Gym" +
                              "\n > P - Gym + Pool" +
                              "\n > T - Personal Training");

            string membershipType = Console.ReadLine();

            MembershipFactory factory = GetFactory(membershipType);
            IMembership membership = factory.GetMembership();

            Console.WriteLine("> Membership you've just created: <\n" +
                              $"\n > Name: {membership.Name}" +
                              $"\n > Description: {membership.Description}" +
                              $"\n > Price: {membership.GetPrice()}");

            Console.ReadKey();
        }

        /// <summary>
        /// Получает нужную фабрику взависимости от типа абонемента
        /// </summary>
        private static MembershipFactory GetFactory(string membershipType) =>
            membershipType.ToLower() switch
            {
                "g" => new GymMembershipFactory(100, "Basic membership"),
                "p" => new GymPlusPoolMembershipFactory(300, "Good price membership"),
                "t" => new PersonalTrainingMembershipFactory(450, "Best for professionals membership"),
                _ => null
            };
    }
}
