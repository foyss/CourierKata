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
    }
}
