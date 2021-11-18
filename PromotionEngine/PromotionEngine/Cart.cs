using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Cart
    {
        public ICollection<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }

        public decimal CalculateTotal()
        {
            return Products?.Sum(p => p.Price) ?? 0;
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }
    }
}
