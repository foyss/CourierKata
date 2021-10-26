using Moq;
using NUnit.Framework;

using CourierKata.Library.Interfaces;
using CourierKata.Library.Services;

namespace CourierKata.UnitTests
{
    public class OrderServiceUnitTests
    {
        private MockRepository _mockRepository;

        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            /* Moq setup */
            _mockRepository = new MockRepository(MockBehavior.Strict);

            /* Interface setup */
            _orderService = new OrderService();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }
    }
}
