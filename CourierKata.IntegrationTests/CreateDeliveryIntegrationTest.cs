using System.Collections.Generic;
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

            var parcelsDeliveryCost = _parcelHelper.GetDeliveryCost(parcels);
        }
    }
}
