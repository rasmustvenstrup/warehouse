using System;
using System.Collections.Generic;

namespace Warehouse.Entities
{
    public class Order : Entity
    {
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        // https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
        public List<OrderProduct> Products { get; set; }

        public void AddProduct(Product product)
        {
            if (Products == null)
            {
                Products = new List<OrderProduct>();
            }

            var orderProduct = new OrderProduct
            {
                Amount = 1,
                Product = product,
            };

            Products.Add(orderProduct);
        }
    }
}