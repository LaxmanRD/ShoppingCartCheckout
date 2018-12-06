namespace ShoppingCartCheckout
{
    public class BuyOneGetOneOfferService : IOfferService
    {
        public int Apply(int productCount, int productCost)
        {
            if (productCount == 0)
            {
                return 0;
            }

            return (productCount / 2) * productCost + (productCount % 2) * productCost;
        }
    }
}
