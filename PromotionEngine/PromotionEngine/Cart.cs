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
            decimal cartTotal = 0;

            if (Promotion != null)
            {
                var promotionTotal = Promotion.Apply(Products);

                cartTotal = promotionTotal;
            }

            cartTotal += Products?.Where(p => !p.PromotionApplied).Sum(p => p.Price) ?? 0;

            return cartTotal;
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
