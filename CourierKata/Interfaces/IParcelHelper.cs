using System.Collections.Generic;
using CourierKata.Models;

namespace CourierKata.Library.Interfaces
{
    public interface IParcelHelper
    {
        decimal GetDeliveryCost(ParcelDimensions parcelDimensions);
        decimal GetDeliveryCost(List<ParcelDimensions> parcels);
    }
}