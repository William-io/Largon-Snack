using Largon_Snack.Domain.StoreContext.Enums;
using System;

namespace Largon_Snack.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery( DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
    }
}
