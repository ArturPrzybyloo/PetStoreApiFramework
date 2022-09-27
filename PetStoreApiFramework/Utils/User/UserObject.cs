using FluentAssertions;
using PetStoreApiFramework.Dto;
using PetStoreApiFramework.Dto.User;
using PetStoreApiFramework.Requests.User;
using System;
using System.Collections.Generic;
using System.Net;

namespace PetStoreApiFramework.Utils.User
{
    public class UserObject
    {
        // Id of user
        public Int64? Id { get; set; }
        // Username
        public string Username { get; set; }
        // First name of user
        public string FirstName { get; set; }
        // Last name of user
        public string LastName { get; set; }
        // Email of user
        public string Email { get; set; }
        // User password
        public string Password { get; set; }
        // User phone number
        public string Phone { get; set; }
        // User status
        public int? UserStatus { get; set; }

        public UserObject()
        {
            var defaultUser = TestData.Read<UserDto>("DefaultUser");
            Id = defaultUser.Id;
            Username = defaultUser.Username;
            FirstName = defaultUser.FirstName;
            LastName = defaultUser.LastName;
            Email = defaultUser.Email;
            Password = defaultUser.Password;
            Phone = defaultUser.Phone;
            UserStatus = defaultUser.UserStatus;
        }
       
        public UserObject GetDeafult()
        {
            var defaultUser = TestData.Read<UserDto>("DefaultUser");
            Id = defaultUser.Id;
            Username = defaultUser.Username;
            FirstName = defaultUser.FirstName;
            LastName = defaultUser.LastName;
            Email = defaultUser.Email;
            Password = defaultUser.Password;
            Phone = defaultUser.Phone;
            UserStatus = defaultUser.UserStatus;
            return this;
        }

        public UserObject Create(int? id = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Id = id;
            var response = RequestsUser.CreateUser(this, statusCode).Deserialize<ApiResponseDto>();
            Id = long.Parse(response.Message);
            return this;
        }

        public UserObject Get(HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null)
        {
            var response = RequestsUser.GetUserByName(Username, statusCode);
            if (statusCode != HttpStatusCode.OK)
            {
                var error = response.Deserialize<ApiResponseDto>();
                error.Message.Should().Be(errorMessage); 
            }
            return this;
        }

        public UserObject Get(string userName, HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null)
        {
            var response = RequestsUser.GetUserByName(userName, statusCode);
            if (statusCode != HttpStatusCode.OK)
            {
                var error = response.Deserialize<ApiResponseDto>();
                error.Message.Should().Be(errorMessage);
            }
            return this;
        }

        public List<UserObject> CreateUsersByList(int numberOfUsers, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            List<UserObject> users = new List<UserObject>();
            for (int i = 0; i < numberOfUsers; i++)
            {
                UserObject user = new UserObject();
                user.GetDeafult();
                users.Add(user);
            }
            RequestsUser.CreateUsersWithList(users, statusCode);
            return users;
        }

        public UserObject[] CreateUsersByArray(int numberOfUsers, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            List<UserObject> users = new List<UserObject>();
            for (int i = 0; i < numberOfUsers; i++)
            {
                UserObject user = new UserObject();
                user.GetDeafult();
                users.Add(user);
            }
            var usersArray = users.ToArray();
            RequestsUser.CreateUsersWithArray(usersArray, statusCode);
            return usersArray;
        }

        public UserObject Update(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = RequestsUser.UpdateUserWithName(Username, this, statusCode ).Deserialize<ApiResponseDto>();
            response.Type.Should().NotBe("unknown");
            return this;
        }

        public UserObject Delete(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsUser.DeleteUserWithName(Username, statusCode);
            return this;
        }

        public UserObject Login(bool inccorectPasswordOrUsername = false, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = RequestsUser.LoginUser(Username, Password, statusCode).Deserialize<ApiResponseDto>();
            if (inccorectPasswordOrUsername)
            {
                response.Message.Should().Contain("Invalid username/password supplied");
            } else
            {
                response.Message.Should().Contain("logged in user session");
            }
            return this;
        }

        public UserObject Logout(bool inccorectPasswordOrUsername = false, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = RequestsUser.LogoutUser(Username, Password, statusCode).Deserialize<ApiResponseDto>();
            if (inccorectPasswordOrUsername)
            {
                response.Message.Should().Contain("Invalid username/password supplied");
            }
            else
            {
                response.Message.Should().Contain("ok");
            }
            return this;
        }
    }
}
