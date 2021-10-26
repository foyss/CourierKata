using System.Collections.Generic;

using CourierKata.Models;

namespace CourierKata.Library.Interfaces
{
    public interface IParcelHelper
    {
        List<ParcelDetails> GetParcelDetails(List<ParcelDimensions> parcels);
    }
}