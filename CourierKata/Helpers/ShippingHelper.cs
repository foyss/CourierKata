using CourierKata.Library.Interfaces;

namespace CourierKata.Library.Helpers
{
    public class ShippingHelper : IShippingHelper
    {
        public decimal SpeedyShipping(decimal parcelDeliveryCost) => parcelDeliveryCost * 2;
    }
}
