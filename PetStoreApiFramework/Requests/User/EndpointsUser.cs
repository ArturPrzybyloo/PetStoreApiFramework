using PetStoreApiFramework.Configuration;
using RestSharp;

namespace PetStoreApiFramework.Requests.User
{
    public static class EndpointsUser
    {
        public static RestRequest CreateUsersWithArray => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/createWithArray", Method.Post);
        public static RestRequest CreateUsersWithList => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/createWithList", Method.Post);
        public static RestRequest GetUserByName => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/{username}", Method.Get);
        public static RestRequest UpdateUserByName => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/{username}", Method.Put);
        public static RestRequest DeleteUserByName => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/{username}", Method.Delete);
        public static RestRequest LoginUser => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/login", Method.Get);
        public static RestRequest LogoutUser => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user/logout", Method.Get);
        public static RestRequest CreateUser => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/user", Method.Post);
    }
}
