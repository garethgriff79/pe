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
    }
}
