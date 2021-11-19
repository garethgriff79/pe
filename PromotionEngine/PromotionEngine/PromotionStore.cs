using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionStore
    {
        private readonly IEnumerable<MultiBuyPromotion> _promotions;

        public PromotionStore()
        {
            _promotions = Enumerable.Empty<MultiBuyPromotion>();
        }

        public PromotionStore(IEnumerable<MultiBuyPromotion> promotions)
        {
            _promotions = promotions;
        }

        public decimal ApplyPromotions(IEnumerable<Product> products)
        {
            decimal promotionTotal = 0;

            // assuming the order promotions are applied doesn't matter with just multi buy promotions
            foreach (var promotion in _promotions)
            {
                promotionTotal += promotion.Apply(products);
            }

            return promotionTotal;
        }
    }
}
