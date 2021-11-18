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
    }
}
