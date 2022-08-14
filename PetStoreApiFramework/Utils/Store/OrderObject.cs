using PetStoreApiFramework.Dto.Store;
using PetStoreApiFramework.Requests.Store;
using System;
using System.Net;


namespace PetStoreApiFramework.Utils.Store
{
    public class OrderObject
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

        public OrderObject GetDefault()
        {
            var defaultOrder = TestData.Read<OrderDto>("DefaultOrder");
            Id = defaultOrder.Id;
            PetId = defaultOrder.PetId;
            Quantity = defaultOrder.Quantity;
            ShipDate = defaultOrder.ShipDate;
            Status = defaultOrder.Status;
            Complete = defaultOrder.Complete;
            return this;
        }

        public OrderObject Get(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsStore.GetOrderById(Id.GetValueOrDefault(), statusCode);
            return this;
        }

        public OrderObject Create(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var createdOrder = RequestsStore.CreateOrder(this, statusCode).Deserialize<OrderDto>();
            Id = createdOrder.Id;
            return this;
        }

        public OrderObject Delete(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsStore.DeleteOrderById(Id.GetValueOrDefault());
            return this;
        }
    }
}
