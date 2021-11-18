namespace PromotionEngine
{
    public class Cart
    {
        public Product Product { get; set; }

        public decimal CalculateTotal()
        {
            return Product?.Price ?? 0;
        }

        public void Add(Product product)
        {
            Product = product;
        }
    }
}
