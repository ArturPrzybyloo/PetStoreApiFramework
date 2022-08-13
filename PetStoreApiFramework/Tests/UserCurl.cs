using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PetStoreApiFramework.Utils.User;
using System.Net;

namespace PetStoreApiFramework.Tests
{
    [AllureNUnit]
    [AllureSuite("Pet Tests")]
    public class UserCurl : TestBase
    {
        [TestCase]
        public void CrudTest()
        {
            UserObject user = new UserObject();
            user.GetDeafult();
            
            user.Username = "BLEBLA12112121aa1xasas";

            user.Create();


            user.Get();

            user.FirstName = "TOBIASZ";
            user.Password = "12345";
            user.Id = null;

            //user.Update();

            user.Delete();

            user.Get(HttpStatusCode.NotFound,"User not found");

            user.CreateUsersByList(5);

            user.Password = "saaasaasas";
            user.Login();

       
        }
    }
}
