using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Domain
{
    internal interface IMembership
    {
        string Name { get; }
        string Description { get; set; }

        decimal GetPrice();
    }
}
