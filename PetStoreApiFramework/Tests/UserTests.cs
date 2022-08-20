using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PetStoreApiFramework.Requests.Store;
using PetStoreApiFramework.Utils;
using PetStoreApiFramework.Utils.User;
using System;
using System.Collections.Generic;
using System.Net;


namespace PetStoreApiFramework.Tests
{
    [AllureNUnit]
    [AllureSuite("Pet Tests")]
    [Category("User Tests")]
    public class UserTests : TestBase
    {
        UserObject user = new UserObject();

        [TestCase]
        [Order(1)]
        public void CreateUsersWithArray()
        {
            user.GetDeafult().Create();
        }
    }
}
