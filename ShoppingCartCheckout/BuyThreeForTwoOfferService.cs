namespace ShoppingCartCheckout
{
    public class BuyThreeForTwoOfferService : IOfferService
    {
        public int Apply(int productCount, int productCost)
        {
            if (productCount == 0)
            {
                return 0;
            }

            return (productCount / 3) * 2 * productCost + (productCount % 3) * productCost;
        }
    }
}
