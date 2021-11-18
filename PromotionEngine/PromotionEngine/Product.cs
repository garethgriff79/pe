namespace PromotionEngine
{
    public class Product
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public bool PromotionApplied { get; set; }

        public Product(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }
    }
}
