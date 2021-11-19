using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interfaces;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void CartWithNoProductsReturnsZeroTotalValue()
        {
            var cart = new Cart(new PromotionStore());

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(0, totalValue);
        }

        [TestMethod]
        public void CartWithProductCalculatesTotalValue()
        {
            var cart = new Cart(new PromotionStore());
            cart.Add(new Product("A", 50));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(50, totalValue);
        }

        [TestMethod]
        public void CartWithMultipleProductsCalculatesTotalValue()
        {
            var cart = new Cart(new PromotionStore());
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));
            cart.Add(new Product("D", 15));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(115, totalValue);
        }

        [TestMethod]
        public void CartWithMultiBuyPromotionCalculatesTotalValue()
        {
            var promotions = new List<MultiBuyPromotion>
            {
                new MultiBuyPromotion("A", 3, 130)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(130, totalValue);
        }

        [TestMethod]
        public void CartWithMultiBuyPromotionAndExcessQuantityCalculatesTotalValue()
        {
            var promotions = new List<MultiBuyPromotion>
            {
                new MultiBuyPromotion("A", 3, 130)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(180, totalValue);
        }

        [TestMethod]
        public void CartWithMultiBuyPromotionAndOtherProductsCalculatesTotalValue()
        {
            var promotions = new List<MultiBuyPromotion>
            {
                new MultiBuyPromotion("A", 3, 130)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(180, totalValue);
        }

        [TestMethod]
        public void CartWithMultiBuyPromotionDoubleSetAndOtherProductsCalculatesTotalValue()
        {
            var promotions = new List<MultiBuyPromotion>
            {
                new MultiBuyPromotion("A", 3, 130)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(310, totalValue);
            Assert.AreEqual(6, cart.Products.Count(p => p.PromotionApplied));
            Assert.AreEqual(6, cart.Products.Count(p => p.PromotionApplied && p.Sku == "A"));
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

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(175, totalValue);
            Assert.AreEqual(5, cart.Products.Count(p => p.PromotionApplied));
            Assert.AreEqual(3, cart.Products.Count(p => p.PromotionApplied && p.Sku == "A"));
            Assert.AreEqual(2, cart.Products.Count(p => p.PromotionApplied && p.Sku == "B"));
        }

        [TestMethod]
        public void CartWithMultiplePromotionsCalculatesTotalValue()
        {
            var promotions = new List<IPromotion>
            {
                new MultiBuyPromotion("A", 3, 130),
                new MultiBuyPromotion("B", 2, 45),
                new CombinationPromotion("C", "D", 30)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(100, totalValue);
            Assert.AreEqual(0, cart.Products.Count(p => p.PromotionApplied));
        }

        [TestMethod]
        public void CartWithMultiplePromotionsCalculatesWithMultiBuy()
        {
            var promotions = new List<IPromotion>
            {
                new MultiBuyPromotion("A", 3, 130),
                new MultiBuyPromotion("B", 2, 45),
                new CombinationPromotion("C", "D", 30)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(370, totalValue);
            Assert.AreEqual(7, cart.Products.Count(p => p.PromotionApplied));
        }

        [TestMethod]
        public void CartWithMultiplePromotionsCalculatesWithMultiBuyAndCombination()
        {
            var promotions = new List<IPromotion>
            {
                new MultiBuyPromotion("A", 3, 130),
                new MultiBuyPromotion("B", 2, 45),
                new CombinationPromotion("C", "D", 30)
            };

            var promotionStore = new PromotionStore(promotions);

            var cart = new Cart(promotionStore);
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));
            cart.Add(new Product("D", 15));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(280, totalValue);
            Assert.AreEqual(9, cart.Products.Count(p => p.PromotionApplied));
        }
    }
}
