using PetStoreApiFramework.Configuration;
using RestSharp;


namespace PetStoreApiFramework.Requests
{
    public static class EndpointsPet
    {
        public static RestRequest GetByPetId => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet/{petId}", Method.Get);
        public static RestRequest CreatePet => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet", Method.Post);
        public static RestRequest UpdatePet => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet", Method.Put);
        public static RestRequest DeletePet => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet/{petId}", Method.Delete);
    }
}
