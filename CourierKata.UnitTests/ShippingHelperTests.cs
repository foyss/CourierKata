using Moq;
using NUnit.Framework;

using CourierKata.Library.Helpers;
using CourierKata.Library.Interfaces;

namespace CourierKata.UnitTests
{
    [TestFixture]
    public class ShippingHelperTests
    {
        private IShippingHelper _shippingHelper;

        private MockRepository _mockRepository;

        [SetUp]
        public void Setup()
        {
            /* Moq setup */
            _mockRepository = new MockRepository(MockBehavior.Strict);

            /* Interface setup */
            _shippingHelper = new ShippingHelper();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [TestCase(100, 200)]
        [TestCase(500, 1000)]
        [TestCase(25000, 50000)]
        public void SpeedyShippingTotalCostTest(decimal totalDeliveryCost, decimal expectedResult)
        {
            /* Arrange */
            /* Act */
            var actualResult = _shippingHelper.SpeedyShipping(totalDeliveryCost);

            /* Assert */
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOf<decimal>(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
