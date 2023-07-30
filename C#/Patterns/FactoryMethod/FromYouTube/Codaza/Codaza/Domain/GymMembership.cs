namespace Codaza.Domain
{
    /// <summary>
    /// Абонемент спортзал.
    /// </summary>
    internal class GymMembership : IMembership
    {
        private readonly string _name;
        private readonly decimal _price;

        public string Name => _name;
        public string Description { get; set; }

        public GymMembership(decimal price)
        {
            _name = "Gym Membership";
            _price = price;
        }

        public decimal GetPrice() => _price;
    }
}
