using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Interfaces;

namespace PromotionEngine
{
    public class MultiBuyPromotion: IPromotion
    {
        private readonly string _sku;
        private readonly int _quantity;
        private readonly decimal _price;

        public MultiBuyPromotion(string sku, int quantity, int price)
        {
            _sku = sku;
            _quantity = quantity;
            _price = price;
        }

        public decimal Apply(IEnumerable<Product> products)
        {
            var availableProducts = products.ToList();
            decimal promotionValue = 0;

            while (availableProducts.Any())
            {
                if (availableProducts.Count(p => p.Sku == _sku) >= _quantity)
                {
                    var numberProductsAppliedTo = 0;

                    foreach (var appliedProduct in products.Where(p => p.Sku == _sku && !p.PromotionApplied))
                    {
                        appliedProduct.PromotionApplied = true;
                        availableProducts.Remove(availableProducts.First(p => p.Sku == _sku));

                        numberProductsAppliedTo++;

                        if (numberProductsAppliedTo == _quantity)
                        {
                            break;
                        }
                    }

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
