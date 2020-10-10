using System;
using System.Collections.Generic;
using System.Text;

namespace Largon_Snack.Domain.StoreContext.Entities
{
    public class Order
    {
        public Customer Customer { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public IList<OrderItem> Items { get; set; }
        public IList<Delivey> Deliveries { get; set; }


        public void Place() { }

    }
}
