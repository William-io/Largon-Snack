using System;
using System.Collections.Generic;
using System.Text;

namespace Largon_Snack.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public DateTime CreateDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
