using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class CombinationPromotionTests
    {
        [TestMethod]
        public void CombinationPromotionSingleSetReturnsValue()
        {
            var products = new List<Product>
            {
                new Product("C", 20),
                new Product("D", 15)
            };

            var promotion = new CombinationPromotion("C", "D", 30);

            var promotionValue = promotion.Apply(products);

            Assert.AreEqual(30, promotionValue);
            Assert.AreEqual(2, products.Count(p => p.PromotionApplied));
        }
    }
}
