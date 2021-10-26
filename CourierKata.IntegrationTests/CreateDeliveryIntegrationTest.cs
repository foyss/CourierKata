using System.Collections.Generic;
using System.Diagnostics;
using CourierKata.Library.Helpers;
using CourierKata.Library.Interfaces;
using CourierKata.Models;
using NUnit.Framework;

namespace CourierKata.IntegrationTests
{
    /// <summary>
    /// NOTE: This test class will be used as an input in order to test the project
    /// </summary>
    [TestFixture]
    public class CreateDeliveryIntegrationTest
    {
        private IParcelHelper _parcelHelper;

        [SetUp]
        public void Setup()
        {
            /* Interface setup */
            _parcelHelper = new ParcelHelper();
        }

        /// <summary>
        /// NOTE: This test will be used as an input in order to test the project
        /// </summary>
        [Test]
        public void CreateOrderTest()
        {
            var parcels = new List<ParcelDimensions>
            {
                new()
                {
                    Length = 5,
                    Width = 10,
                    Height = 20
                },
                new()
                {
                    Length = 50,
                    Width = 20,
                    Height = 100
                }
            };

            var expectedResult = 33;

            var parcelsDeliveryCost = _parcelHelper.GetDeliveryCost(parcels);

            Debug.WriteLine($"Delivery cost match: {expectedResult == parcelsDeliveryCost}");
        }
    }
}
