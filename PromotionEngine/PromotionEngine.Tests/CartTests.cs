using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void CartWithNoProductsReturnsZeroTotalValue()
        {
            var cart = new Cart();

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(0, totalValue);
        }

        [TestMethod]
        public void CartWithProductCalculatesTotalValue()
        {
            var cart = new Cart();
            cart.Add(new Product("A", 50));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(50, totalValue);
        }

        [TestMethod]
        public void CartWithMultipleProductsCalculatesTotalValue()
        {
            var cart = new Cart();
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
            var cart = new Cart();
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.AddPromotion(new MultiBuyPromotion("A", 3, 130));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(130, totalValue);
        }

        [TestMethod]
        public void CartWithMultiBuyPromotionAndExcessQuantityCalculatesTotalValue()
        {
            var cart = new Cart();
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.AddPromotion(new MultiBuyPromotion("A", 3, 130));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(180, totalValue);
        }

        [TestMethod]
        public void CartWithMultiBuyPromotionAndOtherProductsCalculatesTotalValue()
        {
            var cart = new Cart();
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("A", 50));
            cart.Add(new Product("B", 30));
            cart.Add(new Product("C", 20));
            cart.AddPromotion(new MultiBuyPromotion("A", 3, 130));

            var totalValue = cart.CalculateTotal();

            Assert.AreEqual(180, totalValue);
        }
    }
}
