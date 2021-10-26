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
                decimal parcelDeliveryCost = 0;
                bool heavyParcel = t.Weight >= 51;

                if (heavyParcel)
                    parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelWeightEnum.Heavy);

                switch(totalDimensionCount)
                {
                    case < 10:
                        parcelDeliveryCost += 3;

                        if (t.Weight >= 2 && !heavyParcel)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelWeightEnum.Small);

                        break;
                    case < 50:
                        parcelDeliveryCost += 8;

                        if (t.Weight >= 4 && !heavyParcel)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelWeightEnum.Medium);

                        break;

                    case < 100:
                        parcelDeliveryCost += 15;

                        if (t.Weight >= 7 && !heavyParcel)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelWeightEnum.Large);

                        break;
                    case >= 100:
                        parcelDeliveryCost += 25;

                        if (t.Weight >= 11 && !heavyParcel)
                            parcelDeliveryCost += CalculateOverWeightCost(t.Weight, ParcelWeightEnum.XL);

                        break;;
                }

                list.Add(new ParcelDetails {Length = t.Length, Width = t.Width, Height = t.Height, Cost = parcelDeliveryCost});
            }

            return list;
        }

        private decimal CalculateOverWeightCost(decimal weight, ParcelWeightEnum parcelWeight)
        {
            var overWeightCharge = 2;
            var weightLimit = parcelWeight switch
            {
                ParcelWeightEnum.Small => 1,
                ParcelWeightEnum.Medium => 3,
                ParcelWeightEnum.Large => 6,
                ParcelWeightEnum.XL => 10,
                ParcelWeightEnum.Heavy => 50,
                _ => 0
            };

            return parcelWeight == ParcelWeightEnum.Heavy
                ? (weight - weightLimit) + 50
                : (weight - weightLimit) * overWeightCharge;
        }
    }
}
