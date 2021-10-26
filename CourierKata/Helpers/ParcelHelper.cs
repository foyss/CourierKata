using System.Collections.Generic;

using CourierKata.Library.Interfaces;
using CourierKata.Models;

namespace CourierKata.Library.Helpers
{
    public class ParcelHelper : IParcelHelper
    { 
        public List<ParcelDetails> GetParcelDetails(List<ParcelDimensions> parcels)
        {
            var list = new List<ParcelDetails>();
            foreach (var t in parcels)
            {
                decimal totalDimensionCount = t.Height + t.Length + t.Width;
                decimal parcelDeliveryCost;

                switch(totalDimensionCount)
                {
                    case < 10:
                        parcelDeliveryCost = 3;

                        if (t.Weight >= 2)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelSizeEnum.Small);

                        break;
                    case < 50:
                        parcelDeliveryCost = 8;

                        if (t.Weight >= 4)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelSizeEnum.Medium);

                        break;

                    case < 100:
                        parcelDeliveryCost = 15;

                        if (t.Weight >= 7)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelSizeEnum.Large);

                        break;
                    case >= 100:
                        parcelDeliveryCost = 25;

                        if (t.Weight >= 11)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelSizeEnum.XL);

                        break;;
                };
                list.Add(new ParcelDetails {Length = t.Length, Width = t.Width, Height = t.Height, Cost = parcelDeliveryCost});
            }

            return list;
        }

        private decimal CalculateOverWeightCost(decimal weight, ParcelSizeEnum parcelSize)
        {
            var overWeightCharge = 2;
            var weightLimit = parcelSize switch
            {
                ParcelSizeEnum.Small => 1,
                ParcelSizeEnum.Medium => 3,
                ParcelSizeEnum.Large => 6,
                ParcelSizeEnum.XL => 10,
                _ => 0
            };

            return (weight - weightLimit) * overWeightCharge;
        }
    }
}
