namespace PromotionEngine
{
    public class MultiBuyPromotion
    {
        public string Sku { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public MultiBuyPromotion(string sku, int quantity, int price)
        {
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}
