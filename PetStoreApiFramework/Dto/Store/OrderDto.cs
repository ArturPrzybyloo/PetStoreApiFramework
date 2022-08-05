using System;

namespace PetStoreApiFramework.Dto.Store
{
    public class OrderDto
    {
        // Id of order
        public Int64? Id { get; set; }
        // Id of pet
        public Int64? PetId { get; set; }
        // Quantity
        public int? Quantity { get; set; }
        // Shipping date
        public string ShipDate { get; set; }
        // Order status
        public string Status { get; set; }
        // Order completion flag
        public bool Complete { get; set; }
    }
}
