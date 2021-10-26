using System.Collections.Generic;
using System.Linq;

using CourierKata.Library.Interfaces;
using CourierKata.Models;

namespace CourierKata.Library.Helpers
{
    public class ParcelHelper : IParcelHelper
    {
        public ParcelHelper()
        {

        }

        public decimal GetDeliveryCost(ParcelDimensions parcelDimensions)
        {
            var totalDimensionCount = parcelDimensions.Height + parcelDimensions.Length + parcelDimensions.Width;

            return totalDimensionCount switch
            {
                < 10 => 3,
                < 50 => 8,
                < 100 => 15,
                >= 100 => 25
            };
        }

        public decimal GetDeliveryCost(List<ParcelDimensions> parcels) =>
            parcels.Select(t => t.Height + t.Length + t.Width)
                .Select(totalDimensionCount => totalDimensionCount switch
                {
                    < 10 => 3,
                    < 50 => 8,
                    < 100 => 15,
                    >= 100 => 25
                })
                .Aggregate<int, decimal>(0, (current, parcelCost) => current + parcelCost);
    }
}
