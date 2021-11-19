using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class CombinationPromotion
    {
        private readonly string _firstSku;
        private readonly string _secondSku;
        private readonly decimal _price;

        public CombinationPromotion(string firstSku, string secondSku, decimal price)
        {
            _firstSku = firstSku;
            _secondSku = secondSku;
            _price = price;
        }

        public decimal Apply(IEnumerable<Product> products)
        {
            if (products.Any(p => p.Sku == _firstSku) && products.Any(p => p.Sku == _secondSku))
            {
                products.First(p => p.Sku == _firstSku).PromotionApplied = true;
                products.First(p => p.Sku == _secondSku).PromotionApplied = true;
                return _price;
            }

            return 0;
        }
    }
}