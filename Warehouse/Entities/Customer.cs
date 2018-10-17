using Warehouse.Enums;

namespace Warehouse.Entities
{
    public class Customer : Entity
    {
        public Sex Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
