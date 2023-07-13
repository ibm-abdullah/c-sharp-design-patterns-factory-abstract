namespace Factory_Method_Pattern.Business.Models.Shipping.Factories
{
   public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);
        public ShippingProvider GetShippingProvider(string country)
        {
            return CreateShippingProvider(country);
        }
    }
}