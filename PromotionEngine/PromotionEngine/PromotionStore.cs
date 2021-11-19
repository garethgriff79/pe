using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Interfaces;

namespace PromotionEngine
{
    public class PromotionStore
    {
        private readonly IEnumerable<IPromotion> _promotions;

        public PromotionStore()
        {
            _promotions = Enumerable.Empty<IPromotion>();
        }

        public PromotionStore(IEnumerable<IPromotion> promotions)
        {
            _promotions = promotions;
        }

        public decimal ApplyPromotions(IEnumerable<Product> products)
        {
            decimal promotionTotal = 0;

            // assuming the order promotions are applied doesn't matter if different promotions are mutually exclusive
            foreach (var promotion in _promotions)
            {
                promotionTotal += promotion.Apply(products);
            }

            return promotionTotal;
        }
    }
}
