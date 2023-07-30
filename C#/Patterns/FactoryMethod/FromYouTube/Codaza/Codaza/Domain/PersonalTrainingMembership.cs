using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Domain
{
    /// <summary>
    /// Абонемент персональной тренировки.
    /// </summary>
    class PersonalTrainingMembership : IMembership
    {
        private readonly string _name;
        private readonly decimal _price;

        public string Name => _name;
        public string Description { get; set; }

        public PersonalTrainingMembership(decimal price)
        {
            _name = "Personal Training Membership";
            _price = price;
        }

        public decimal GetPrice() => _price;

    }
}
