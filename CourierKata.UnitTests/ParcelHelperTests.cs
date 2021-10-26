using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

using CourierKata.Library.Helpers;
using CourierKata.Library.Interfaces;
using CourierKata.Models;

namespace CourierKata.UnitTests
{
    [TestFixture]
    public class ParcelHelperTests
    {
        private MockRepository _mockRepository;

        private IParcelHelper _parcelHelper;

        [SetUp]
        public void Setup()
        {
            /* Moq setup */
            _mockRepository = new MockRepository(MockBehavior.Strict);

            /* Interface setup */
            _parcelHelper = new ParcelHelper();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [TestCase(1, 1, 1, 3)]
        [TestCase(5, 5, 5, 8)]
        [TestCase(25, 25, 25, 15)]
        [TestCase(100, 100, 100, 25)]
        public void ParcelDeliveryCostTest(decimal length, decimal width, decimal height, decimal expectedResult)
        {
            /* Arrange */
            var parcelDimensions = new List<ParcelDimensions>
            {
                new()
                {
                    Length = length,
                    Width = width,
                    Height = height
                }
            };

            /* Act */
            var actualResult = _parcelHelper.GetParcelDetails(parcelDimensions);

            /* Assert */
            var parcelCost = actualResult.FirstOrDefault().Cost;

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, parcelCost);
            Assert.IsInstanceOf<List<ParcelDetails>>(actualResult);
        }
    }
}
