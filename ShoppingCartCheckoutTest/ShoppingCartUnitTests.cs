using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartCheckout;
using System.Collections.Generic;

namespace ShoppingCartCheckoutTest
{
    [TestClass]
    public class ShoppingCartUnitTests
    {
        [TestMethod]
        public void Test_GenerateBillFor3Apples1Orange()
        {
            CheckoutSystem checkoutSystem = new CheckoutSystem();

            List<string> itemList = new List<string> { "Apple", "Apple", "Apple", "Orange" };
            string result = checkoutSystem.GenerateBill(itemList, false);

            Assert.AreEqual("£2.05", result);
        }

        [TestMethod]
        public void Test_GenerateBillFor2Apples3Oranges()
        {
            CheckoutSystem checkoutSystem = new CheckoutSystem();

            List<string> itemList = new List<string> { "Apple", "Apple", "Orange", "Orange", "Orange" };
            string result = checkoutSystem.GenerateBill(itemList, false);

            Assert.AreEqual("£1.95", result);
        }

        [TestMethod]
        public void BuyOneGetOneOfferService_Test()
        {
            //given
            BuyOneGetOneOfferService buy1Get1Offer = new BuyOneGetOneOfferService();
            int result = buy1Get1Offer.Apply(1, 60);
            int result1 = buy1Get1Offer.Apply(2, 60);
            int result2 = buy1Get1Offer.Apply(3, 60);

            //then
            Assert.AreEqual(60, result);
            Assert.AreEqual(60, result1);
            Assert.AreEqual(120, result2);
        }

        [TestMethod]
        public void BuyThreeForTwoOfferService_Test()
        {
            BuyThreeForTwoOfferService Buy3For2Offer = new BuyThreeForTwoOfferService();
            int result = Buy3For2Offer.Apply(1, 60);
            int result1 = Buy3For2Offer.Apply(2, 60);
            int result2 = Buy3For2Offer.Apply(3, 60);
            int result3 = Buy3For2Offer.Apply(4, 60);

            //then
            Assert.AreEqual(60, result);
            Assert.AreEqual(120, result1);
            Assert.AreEqual(120, result2);
            Assert.AreEqual(180, result3);
        }

        [TestMethod]
        public void GenerateBillForShoppingCart_ContainingApplesWithBuyOneGetOneOffer_Test()
        {
            //given
            CheckoutSystem checkoutSystem = new CheckoutSystem(new OfferServiceFactory());

            List<string> itemList = new List<string> { "Apple", "Apple", "Apple", "Apple" };
            string result = checkoutSystem.GenerateBill(itemList, true);

            List<string> itemList1 = new List<string> { "Apple", "Apple", "Apple" };
            string result1 = checkoutSystem.GenerateBill(itemList1, true);

            Assert.AreEqual("£1.20", result);
            Assert.AreEqual("£1.20", result1);
        }

        [TestMethod]
        public void GenerateBillForShoppingCart_ContainingOrangesAfterBuy3for2Offer_Test()
        {
            //given
            CheckoutSystem checkoutSystem = new CheckoutSystem(new OfferServiceFactory());

            List<string> itemList = new List<string> { "Orange", "Orange", "Orange", "Orange" };
            string result = checkoutSystem.GenerateBill(itemList, true);

            List<string> itemList1 = new List<string> { "Orange", "Orange", "Orange", "Orange", "Orange", "Orange" };
            string result1 = checkoutSystem.GenerateBill(itemList1, true);

            List<string> itemList2 = new List<string> { "Orange", "Orange", "Orange", "Orange", "Orange" };
            string result2 = checkoutSystem.GenerateBill(itemList2, true);

            Assert.AreEqual("£0.75", result);
            Assert.AreEqual("£1.00", result1);
            Assert.AreEqual("£1.00", result2);
        }

        [TestMethod]
        public void GenerateBillForShoppingCart_ContainingApplesandOrangeswithOffers_Test()
        {

            CheckoutSystem checkoutSystem = new CheckoutSystem(new OfferServiceFactory());

            List<string> itemList = new List<string> { "Apple", "Apple", "Apple", "Orange" };
            string result = checkoutSystem.GenerateBill(itemList, true);

            List<string> itemList1 = new List<string> { "Apple", "Apple", "Apple", "Orange", "Orange", "Orange" };
            string result1 = checkoutSystem.GenerateBill(itemList1, true);

            List<string> itemList2 = new List<string> { "Apple", "Apple", "Orange", "Orange", "Orange" };
            string result2 = checkoutSystem.GenerateBill(itemList2, true);

            Assert.AreEqual("£1.45", result);
            Assert.AreEqual("£1.70", result1);
            Assert.AreEqual("£1.10", result2);
        }
    }
}