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

        [Test]
        public void BasicSmallParcelTest()
        {
            /* Arrange */
            var parcelDimensions = new ParcelDimensions
            {
                Length = 1,
                Width = 1,
                Height = 1
            };
            var expectedResult = 3;

            /* Act */
            var actualResult = _parcelHelper.GetDeliveryCost(parcelDimensions);

            /* Assert */
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
