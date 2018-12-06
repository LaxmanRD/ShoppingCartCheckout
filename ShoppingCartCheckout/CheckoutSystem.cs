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
        private static string APPLE = "Apple";
        private static string ORANGE = "Orange";

        private PriceCalculation _priceCalculation = null;

        private OfferServiceFactory offerServiceFactory;

        public CheckoutSystem()
        {
            _priceCalculation = new PriceCalculation();
        }

        public CheckoutSystem(OfferServiceFactory offerServiceFactory)
        {
            this.offerServiceFactory = offerServiceFactory;
        }

        /// <summary>
        /// This will generate the bill in currency format
        /// </summary>
        /// <param name="shoppingCart">list of items added to the shopping cart</param>
        /// <param name="offersExist">true, if any offers available for the products</param>
        /// <returns>total amount in currency format</returns>
        public string GenerateBill(List<String> shoppingCart, bool offersExist)
        {
            double total = calculateTotal(shoppingCart, offersExist) * .01;
            return total.ToString("C", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// This will calculate the total bill for the items in the shopping cart
        /// </summary>
        /// <param name="shoppingCart">list of items added to the shopping cart </param>
        /// <param name="offersExist">true, if any offers available for the products</param>
        /// <returns>total amount</returns>
        private double calculateTotal(List<String> shoppingCart, bool offersExist)
        {
            int total = 0;

            int apples = shoppingCart.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).Where(x => x.Key == APPLE).FirstOrDefault().Value;
            if (offersExist)
            {
                total += offerServiceFactory.offerFor(APPLE).Apply(apples, APPLE_COST);
            }
            else
            {
                total += _priceCalculation.Apply(apples, APPLE_COST);
            }


            int oranges = shoppingCart.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).Where(x => x.Key == ORANGE).FirstOrDefault().Value;
            if (offersExist)
            {
                total += offerServiceFactory.offerFor(ORANGE).Apply(oranges, ORANGE_COST);
            }
            else
            {
                total += _priceCalculation.Apply(oranges, ORANGE_COST);
            }

            return total;
        }
    }
}