using System;

namespace ShoppingCartCheckout
{
    [Serializable]
    internal class IllegalArgumentException : Exception
    {
        public IllegalArgumentException()
        {
        }

        public IllegalArgumentException(string message) : base(message)
        {
            throw new Exception("Item not found in the shopping cart : " + message);
        }
    }
}