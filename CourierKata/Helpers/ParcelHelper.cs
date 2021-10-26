using System.Collections.Generic;
using System.Linq;

using CourierKata.Library.Interfaces;
using CourierKata.Models;

namespace CourierKata.Library.Helpers
{
    public class ParcelHelper : IParcelHelper
    { 
        public List<ParcelDetails> GetParcelDetails(List<ParcelDimensions> parcels) =>
            (from t in parcels
                let totalDimensionCount = t.Height + t.Length + t.Width
                let parcelDeliveryCost = totalDimensionCount switch
                {
                    < 10 => 3,
                    < 50 => 8,
                    < 100 => 15,
                    >= 100 => 25
                }
                select new ParcelDetails {Length = t.Length, Width = t.Width, Height = t.Height, Cost = parcelDeliveryCost}).ToList();
    }
}
