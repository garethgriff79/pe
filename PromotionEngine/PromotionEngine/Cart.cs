using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Cart
    {
        public ICollection<Product> Products { get; set; }
        public MultiBuyPromotion Promotion { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }

        public decimal CalculateTotal()
        {
            if (Promotion != null)
            {
                if (Products.Count(p => p.Sku == Promotion.Sku) == Promotion.Quantity)
                {
                    return Promotion.Price;
                }
            }
            
            return Products?.Sum(p => p.Price) ?? 0;
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }

        public void AddPromotion(MultiBuyPromotion promotion)
        {
            Promotion = promotion;
        }
    }
}
