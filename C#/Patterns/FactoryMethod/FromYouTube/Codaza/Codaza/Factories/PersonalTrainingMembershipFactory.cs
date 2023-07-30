using Codaza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Factories
{
    class PersonalTrainingMembershipFactory : MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public PersonalTrainingMembershipFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            PersonalTrainingMembership gymPlusPoolMembership = new PersonalTrainingMembership(_price)
            {
                Description = _description
            };

            return gymPlusPoolMembership;
        }
    }
}
