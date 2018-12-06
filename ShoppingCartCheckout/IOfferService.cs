namespace ShoppingCartCheckout
{
    public interface IOfferService
    {
        int Apply(int productCount, int productCost);
    }
}
