﻿using Factory_Method_Pattern.Business.Models.Commerce;
using Factory_Method_Pattern.Business.Models.Shipping;
using Factory_Method_Pattern.Business.Models.Shipping.Factories;
using System.Runtime.CompilerServices;

namespace Factory_Method_Pattern.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private ShippingProviderFactory shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            this.order = order;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = shippingProviderFactory.CreateShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
