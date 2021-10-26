using System.Collections.Generic;
using System.Linq;
using CourierKata.Library.Helpers;
using CourierKata.Library.Interfaces;
using CourierKata.Models;

namespace CourierKata.Library.Services
{
    public class OrderService : IOrderService
    {
        private readonly IParcelHelper _parcelHelper;
        private readonly IShippingHelper _shippingHelper;

        public OrderService()
        {
            // These could be injected in via DI should the format of the project be different
            _parcelHelper = new ParcelHelper();
            _shippingHelper = new ShippingHelper();
        }
        public OrderDetails CreateOrder(List<ParcelDimensions> parcelDimensionsList, bool speedyShipping)
        {
            var parcelDetailsList = _parcelHelper.GetParcelDetails(parcelDimensionsList);
            var parcelDetailsCostSum = parcelDetailsList.Sum(t => t.Cost);

            if (speedyShipping)
                parcelDetailsCostSum = _shippingHelper.SpeedyShipping(parcelDetailsCostSum);

            return new OrderDetails
            {
                Parcels = parcelDetailsList,
                TotalCost = parcelDetailsCostSum
            };
        }
    }
}
