using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShoppingCartCheckout
{
    public class CheckoutSystem
    {
        private static int APPLE_COST = 60;
        private static int ORANGE_COST = 25;

        private PriceCalculation _priceCalculation = null;

        public CheckoutSystem()
        {
            _priceCalculation = new PriceCalculation();
        }

        /// <summary>
        /// This will generate the bill in currency format
        /// </summary>
        /// <param name="shoppingCart">list of items added to the shopping cart</param>
        /// <returns>total amount in currency format</returns>
        public string GenerateBill(List<String> shoppingCart)
        {
            double total = calculateTotal(shoppingCart) * .01;
            return total.ToString("C", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// This will calculate the total bill for the items in the shopping cart
        /// </summary>
        /// <param name="shoppingCart">list of items added to the shopping cart </param>
        /// <returns>total amount</returns>
        private int calculateTotal(List<String> shoppingCart)
        {
            int total = 0;

            int apples = shoppingCart.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).Where(x => x.Key == "Apple").FirstOrDefault().Value;
            total += _priceCalculation.Apply(apples, APPLE_COST);

            int oranges = shoppingCart.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).Where(x => x.Key == "Orange").FirstOrDefault().Value;
            total += _priceCalculation.Apply(oranges, ORANGE_COST);

            return total;
        }
    }
}