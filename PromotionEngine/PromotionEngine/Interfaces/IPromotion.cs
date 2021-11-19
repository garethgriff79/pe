using System.Collections.Generic;

namespace PromotionEngine.Interfaces
{
    public interface IPromotion
    {
        decimal Apply(IEnumerable<Product> products);
    }
}
