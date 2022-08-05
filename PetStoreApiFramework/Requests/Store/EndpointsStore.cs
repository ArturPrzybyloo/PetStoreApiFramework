using PetStoreApiFramework.Configuration;
using RestSharp;


namespace PetStoreApiFramework.Requests.Store
{
    public static class EndpointsStore
    {
        public static RestRequest PlaceOrder => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/store/order", Method.Post);
        public static RestRequest GetOrder => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/store/order/{orderId}", Method.Get);
        public static RestRequest DeleteOrder => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/store/order/{orderId}", Method.Delete);
        public static RestRequest GetInventory => new RestRequest(ConfigProvider.CurrentEnviroment.Url  + "/store/inventory", Method.Get);
    }
}
