namespace ShoppingCartCheckout
{
    public class PriceCalculation
    {
        public int Apply(int itemCount, int itemCost)
        {
            if (itemCount == 0)
            {
                return 0;
            }

            return itemCount * itemCost;
        }
    }
}
