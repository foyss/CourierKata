using System.Collections.Generic;
using Moq;
using NUnit.Framework;

using CourierKata.Library.Interfaces;
using CourierKata.Library.Services;
using CourierKata.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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

        [TestCase(1, 1, 1, true)]
        public void CreateOrderTests(decimal length, decimal width, decimal height, bool speedyShipping)
        {
            /* Arrange */
            var listOfParcels = new List<ParcelDimensions>
            {
                new()
                {
                    Length = length,
                    Width = width,
                    Height = height
                }
            };

            /* Act */
            var actualResult = _orderService.CreateOrder(listOfParcels, speedyShipping);

            /* Assert */
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOf<OrderDetails>(actualResult);
        }
    }
}
