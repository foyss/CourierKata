using System.Collections.Generic;

using CourierKata.Models;

namespace CourierKata.Library.Interfaces
{
    public interface IOrderService
    {
        OrderDetails CreateOrder(List<ParcelDimensions> parcelDimensionsList, bool speedyDelivery);
    }
}