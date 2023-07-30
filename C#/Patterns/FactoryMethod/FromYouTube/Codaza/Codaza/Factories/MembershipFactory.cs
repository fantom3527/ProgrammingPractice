using Codaza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codaza.Factories
{
    /// <summary>
    /// Фабрика абонементов.
    /// </summary>
    internal abstract class MembershipFactory
    {
        public abstract IMembership GetMembership();
    }
}
