using CourierKata.Models;

namespace CourierKata.Library.Interfaces
{
    public interface IParcelHelper
    {
        decimal GetDeliveryCost(ParcelDimensions parcelDimensions);
    }
}