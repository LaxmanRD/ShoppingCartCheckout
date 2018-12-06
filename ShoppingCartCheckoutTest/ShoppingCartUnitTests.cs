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
            string result = checkoutSystem.GenerateBill(itemList);

            Assert.AreEqual("£2.05", result);
        }

        [TestMethod]
        public void Test_GenerateBillFor2Apples3Oranges()
        {
            CheckoutSystem checkoutSystem = new CheckoutSystem();

            List<string> itemList = new List<string> { "Apple", "Apple", "Orange", "Orange", "Orange" };
            string result = checkoutSystem.GenerateBill(itemList);

            Assert.AreEqual("£1.95", result);
        }
    }
}
