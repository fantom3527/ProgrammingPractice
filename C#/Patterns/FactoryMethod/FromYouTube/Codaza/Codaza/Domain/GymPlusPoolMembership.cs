using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Domain
{
    /// <summary>
    /// Абонемент спортзал + бассейн.
    /// </summary>
    class GymPlusPoolMembership : IMembership
    {
        private readonly string _name;
        private readonly decimal _price;

        public string Name => _name;
        public string Description { get; set; }

        public GymPlusPoolMembership(decimal price)
        {
            _name = "Gym + Pool Membership";
            _price = price;
        }

        public decimal GetPrice() => _price;

    }
}
