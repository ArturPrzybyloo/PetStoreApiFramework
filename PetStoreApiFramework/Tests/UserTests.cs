using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PetStoreApiFramework.Dto;
using PetStoreApiFramework.Requests.User;
using PetStoreApiFramework.Utils;
using PetStoreApiFramework.Utils.User;
using System.Net;

namespace PetStoreApiFramework.Tests
{
    [AllureNUnit]
    [AllureSuite("User Tests")]
    [Category("User Tests")]
    public class UserTests : TestBase
    {
        UserObject user = new UserObject();

        [TestCase]
        [Order(1)]
        public void CreateUsersWithList()
        {
            // Create users by list
            var users = user.CreateUsersByList(3);

            // Verify that users are created
            var firstUser = RequestsUser.GetUserByName(users[0].Username).Deserialize<UserObject>();
            firstUser.Email.Should().Be(users[0].Email);

            var secondUser = RequestsUser.GetUserByName(users[1].Username).Deserialize<UserObject>();
            secondUser.LastName.Should().Be(users[1].LastName);

            var thirdUser = RequestsUser.GetUserByName(users[2].Username).Deserialize<UserObject>();
            thirdUser.Phone.Should().Be(users[2].Phone);
        }

        [TestCase]
        [Order(2)]
        public void CreateUsersWithArray()
        {
            // Create users by list
            var users = user.CreateUsersByArray(3);

            // Verify that users are created
            var firstUser = RequestsUser.GetUserByName(users[0].Username).Deserialize<UserObject>();
            firstUser.Email.Should().Be(users[0].Email);

            var secondUser = RequestsUser.GetUserByName(users[1].Username).Deserialize<UserObject>();
            secondUser.LastName.Should().Be(users[1].LastName);

            var thirdUser = RequestsUser.GetUserByName(users[2].Username).Deserialize<UserObject>();
            thirdUser.Phone.Should().Be(users[2].Phone);
        }

        [TestCase]
        [Order(3)]
        public void CreateUser()
        {
            // Create user
            user.GetDeafult().Create();

            // Get user and verify it's data
            var createdUser = RequestsUser.GetUserByName(user.Username).Deserialize<UserObject>();
            createdUser.FirstName.Should().Be(user.FirstName);
        }

        [TestCase]
        [Order(4)]
        public void DeleteUser()
        {
            // Create user
            user.GetDeafult().Create();

            // Delete user
            user.Delete();

            // Verify that user is deleted
            var response = RequestsUser.GetUserByName(user.Username, HttpStatusCode.NotFound).Deserialize<ApiResponseDto>();
            response.Message.Should().Be("User not found");
        }

        [TestCase]
        [Order(5)]
        public void UpdateUser()
        {
            // Create user
            user.GetDeafult().Create();

            // Prepare Data to update
            var newName = Faker.Name.FullName();
            var newEmail = Faker.Internet.Email();
            user.Email = newEmail;
            user.FirstName = newName;

            // Update user
            user.Update();

            // Get user and verify changes
            var createdUser = RequestsUser.GetUserByName(user.Username).Deserialize<UserObject>();
            createdUser.FirstName.Should().Be(newName);
            createdUser.Email.Should().Be(newEmail);
        }
    }
}
