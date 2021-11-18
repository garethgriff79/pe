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
            if (products.Count(p => p.Sku == Sku) >= Quantity)
            {
                var numberProductsAppliedTo = 0;

                foreach (var appliedProduct in products.Where(p => p.Sku == Sku))
                {
                    appliedProduct.PromotionApplied = true;

                    numberProductsAppliedTo++;

                    if (numberProductsAppliedTo == Quantity)
                    {
                        break;
                    }
                }

                return Price;
            }

            return 0;
        }
    }
}
