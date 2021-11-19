using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Cart
    {
        private readonly PromotionStore _promotionStore;
        public ICollection<Product> Products { get; set; }
        
        public Cart(PromotionStore promotionStore)
        {
            _promotionStore = promotionStore;

            Products = new List<Product>();
        }

        public decimal CalculateTotal()
        {
            decimal cartTotal = 0;

            var promotionTotal = _promotionStore.ApplyPromotions(Products);

            cartTotal = promotionTotal;

            cartTotal += Products?.Where(p => !p.PromotionApplied).Sum(p => p.Price) ?? 0;

            return cartTotal;
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }
    }
}
