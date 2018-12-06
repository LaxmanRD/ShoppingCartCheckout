namespace ShoppingCartCheckout
{
    public class PriceCalculation
    {
        public int Apply(int productCount, int productCost)
        {
            if (productCount == 0)
            {
                return 0;
            }

            return productCount * productCost;
        }
    }
}
