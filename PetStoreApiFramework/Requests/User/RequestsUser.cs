﻿using FluentAssertions;
using PetStoreApiFramework.Configuration;
using PetStoreApiFramework.Dto.User;
using PetStoreApiFramework.Utils;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace PetStoreApiFramework.Requests.User
{
    public static class RequestsUser
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

        public static RestResponse CreateUsersWithArray(UserDto[] userDtoArray, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.CreateUsersWithArray.AddJsonBody(userDtoArray);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse CreateUsersWithList(List<UserDto> userDtoList, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.CreateUsersWithArray.AddJsonBody(userDtoList);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse GetUserByName(string userName, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.GetUserByName.AddUrlSegment("username", userName);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse UpdateUserWithName(string userName, UserDto userDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.UpdateUserByName.AddUrlSegment("username", userName)
                .AddBody(userDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse DeleteUserWithName(string userName, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.DeleteUserByName.AddUrlSegment("username", userName);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse LoginUser(string userName, string password, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.LoginUser.AddParameter(userName, password);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse LogoutUser(string userName, string password, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.LogoutUser.AddParameter(userName, password);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse CreateUser(UserDto userDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsUser.CreateUser.AddBody(userDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }
    }
}