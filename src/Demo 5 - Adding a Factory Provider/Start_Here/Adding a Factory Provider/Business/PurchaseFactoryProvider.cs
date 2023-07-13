using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Adding_a_Factory_Provider.Business
{
    public class PurchaseFactoryProvider
    {
        private IEnumerable<Type> factories;

        public PurchaseFactoryProvider()
        {
            this.factories = Assembly.GetAssembly(typeof(PurchaseFactoryProvider))
                .GetTypes()
                .Where(x => typeof(IPurchaseProviderFactory).IsAssignableFrom(x));
        }

        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            var factory = factories
                .Single(t => t.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            var instance = (IPurchaseProviderFactory)Activator.CreateInstance(factory);
            return instance;
        }
    }
}