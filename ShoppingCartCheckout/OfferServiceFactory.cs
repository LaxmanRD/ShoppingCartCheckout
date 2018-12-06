namespace ShoppingCartCheckout
{
    public class OfferServiceFactory
    {
        public IOfferService offerFor(string name)
        {
            switch (name.ToLower())
            {
                case ("apple"):
                    return new BuyOneGetOneOfferService();
                case ("orange"):
                    return new BuyThreeForTwoOfferService();
                default:
                    throw new IllegalArgumentException(name + " Item not listed");
            }
        }
    }
}
