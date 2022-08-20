using FluentAssertions;
using PetStoreApiFramework.Configuration;
using PetStoreApiFramework.Dto.Store;
using PetStoreApiFramework.Utils;
using PetStoreApiFramework.Utils.Store;
using RestSharp;
using System;
using System.Net;

namespace PetStoreApiFramework.Requests.Store
{
    public static class RequestsStore
    {
        private static RestClient client;
        private static RestClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new RestClient(ConfigProvider.CurrentEnviroment.Url);
                }
                return client;
            }
        }

        public static RestResponse GetOrderById(long orderId, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsStore.GetOrder.AddUrlSegment("orderId", orderId);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse CreateOrder(OrderDto orderDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsStore.PlaceOrder.AddBody(orderDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse CreateOrder(OrderObject orderDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsStore.PlaceOrder.AddBody(orderDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse DeleteOrderById(long orderId, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsStore.DeleteOrder.AddUrlSegment("orderId", orderId);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse GetInventory(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsStore.GetInventory;

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }
    }
}
