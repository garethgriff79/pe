using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class PromotionStoreTests
    {
        [TestMethod]
        public void CartWithMultiBuyPromotionCalculatesTotalValue()
        {
            var promotions = new List<MultiBuyPromotion>
            {
                new MultiBuyPromotion("A", 3, 130)
            };

            var promotionStore = new PromotionStore(promotions);

            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50)
            };

            var totalValue = promotionStore.ApplyPromotions(products);

            Assert.AreEqual(130, totalValue);
            Assert.AreEqual(3, products.Count(p => p.PromotionApplied));
        }

        [TestMethod]
        public void CartWithMultipleMultiBuyPromotionsCalculatesTotalValue()
        {
            var promotions = new List<MultiBuyPromotion>
            {
                new MultiBuyPromotion("A", 3, 130),
                new MultiBuyPromotion("B", 2, 45)
            };

            var promotionStore = new PromotionStore(promotions);
            
            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("B", 30),
                new Product("B", 30)
            };

            var totalValue = promotionStore.ApplyPromotions(products);

            Assert.AreEqual(175, totalValue);
            Assert.AreEqual(5, products.Count(p => p.PromotionApplied));
            Assert.AreEqual(3, products.Count(p => p.PromotionApplied && p.Sku == "A"));
            Assert.AreEqual(2, products.Count(p => p.PromotionApplied && p.Sku == "B"));
        }
    }
}
