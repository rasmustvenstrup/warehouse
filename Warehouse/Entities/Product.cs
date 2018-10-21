using System.Collections.Generic;

namespace Warehouse.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }

        // https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
        public IEnumerable<OrderProduct> Products { get; set; }
    }
}