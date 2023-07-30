using Codaza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Factories
{
    internal class GymPlusPoolMembershipFactory : MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public GymPlusPoolMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            GymPlusPoolMembership gymPlusPoolMembership = new GymPlusPoolMembership(_price)
            {
                Description = _description
            };

            return gymPlusPoolMembership;
        }
    }
}
