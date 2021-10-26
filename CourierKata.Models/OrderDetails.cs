using System.Collections.Generic;

namespace CourierKata.Models
{
    public class OrderDetails
    {
        public List<ParcelDetails> Parcels { get; set; }
        public decimal TotalCost { get; set; }
    }
}
