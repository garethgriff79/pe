using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class MultiPromotionTests
    {
        [TestMethod]
        public void MultiBuyPromotionSingleSetReturnsValue()
        {
            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50)
            };
            
            var promotion = new MultiBuyPromotion("A", 3, 130);

            var promotionValue = promotion.Apply(products);

            Assert.AreEqual(130, promotionValue);
        }

        [TestMethod]
        public void MultiBuyPromotionDoubleSetReturnsDoubleValue()
        {
            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50)
            };

            var promotion = new MultiBuyPromotion("A", 3, 130);

            var promotionValue = promotion.Apply(products);

            Assert.AreEqual(260, promotionValue);
            Assert.AreEqual(6, products.Count(p => p.PromotionApplied));
        }

        [TestMethod]
        public void MultiBuyPromotionSingleSetWithExcessReturnsSingleValue()
        {
            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50)
            };

            var promotion = new MultiBuyPromotion("A", 3, 130);

            var promotionValue = promotion.Apply(products);

            Assert.AreEqual(130, promotionValue);
            Assert.AreEqual(3, products.Count(p => p.PromotionApplied));
        }
    }
}
