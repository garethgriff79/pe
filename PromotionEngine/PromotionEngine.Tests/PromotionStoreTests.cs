using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interfaces;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class PromotionStoreTests
    {
        [TestMethod]
        public void PromotionStoreWithMultiBuyPromotionCalculatesTotalValue()
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
        public void PromotionStoreWithMultipleMultiBuyPromotionsCalculatesTotalValue()
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

        [TestMethod]
        public void PromotionStoreWithMultiBuyAndCombinationCalculatesTotalValue()
        {
            var promotions = new List<IPromotion>
            {
                new MultiBuyPromotion("A", 3, 130),
                new CombinationPromotion("C", "D", 30)
            };

            var promotionStore = new PromotionStore(promotions);

            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("C", 20),
                new Product("D", 15)
            };

            var totalValue = promotionStore.ApplyPromotions(products);

            Assert.AreEqual(160, totalValue);
            Assert.AreEqual(5, products.Count(p => p.PromotionApplied));
        }

        [TestMethod]
        public void PromotionStoreWithOverlappingMultiBuyAndCombinationCalculatesOnlyOnePromotionApplies()
        {
            var promotions = new List<IPromotion>
            {
                new MultiBuyPromotion("A", 3, 130),
                new CombinationPromotion("A", "D", 60)
            };

            var promotionStore = new PromotionStore(promotions);

            var products = new List<Product>
            {
                new Product("A", 50),
                new Product("A", 50),
                new Product("A", 50),
                new Product("D", 15)
            };

            var totalValue = promotionStore.ApplyPromotions(products);

            Assert.AreEqual(130, totalValue);
            Assert.AreEqual(3, products.Count(p => p.PromotionApplied));
            Assert.AreEqual(3, products.Count(p => p.PromotionApplied && p.Sku == "A"));
        }
    }
}
