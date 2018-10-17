using System;
using System.Collections.Generic;

namespace Warehouse.Entities
{
    public class Order : Entity
    {
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}