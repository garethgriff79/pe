using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Interfaces;

namespace PromotionEngine
{
    public class CombinationPromotion: IPromotion
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
            var availableProducts = products.ToList();
            decimal promotionValue = 0;

            while (availableProducts.Any())
            {
                if (availableProducts.Any(p => p.Sku == _firstSku && !p.PromotionApplied) && availableProducts.Any(p => p.Sku == _secondSku && !p.PromotionApplied))
                {
                    var firstProduct = products.First(p => p.Sku == _firstSku && !p.PromotionApplied);
                    var secondProduct = products.First(p => p.Sku == _secondSku && !p.PromotionApplied);

                    firstProduct.PromotionApplied = true;
                    secondProduct.PromotionApplied = true;

                    availableProducts.Remove(firstProduct);
                    availableProducts.Remove(secondProduct);

                    promotionValue += _price;
                }
                else
                {
                    availableProducts = new List<Product>();
                }
            }

            return promotionValue;
        }
    }
}