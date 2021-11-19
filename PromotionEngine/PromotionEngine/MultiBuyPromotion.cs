using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class MultiBuyPromotion
    {
        public string Sku { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public MultiBuyPromotion(string sku, int quantity, int price)
        {
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }

        public decimal Apply(IEnumerable<Product> products)
        {
            var availableProducts = products.ToList();
            decimal promotionValue = 0;

            while (availableProducts.Any())
            {
                if (availableProducts.Count(p => p.Sku == Sku) >= Quantity)
                {
                    var numberProductsAppliedTo = 0;

                    foreach (var appliedProduct in products.Where(p => p.Sku == Sku && !p.PromotionApplied))
                    {
                        appliedProduct.PromotionApplied = true;
                        availableProducts.Remove(availableProducts.First(p => p.Sku == Sku));

                        numberProductsAppliedTo++;

                        if (numberProductsAppliedTo == Quantity)
                        {
                            break;
                        }
                    }

                    promotionValue += Price;
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
