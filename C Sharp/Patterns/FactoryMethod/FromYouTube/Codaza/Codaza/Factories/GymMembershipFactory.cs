using Codaza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Factories
{
    /// <summary>
    /// Фабрика для абонемента спортзал 
    /// </summary>
    class GymMembershipFactory : MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public GymMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            GymMembership gymMembership = new GymMembership(_price)
            {
                Description = _description
            };

            return gymMembership;
        }
    }
}
