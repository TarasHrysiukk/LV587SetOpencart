using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Tests.LoginFormTest
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[LoginForm]")]
    [AllureDisplayIgnored]
    class LoginTestApiTest
    {
        [Test]
        [AllureTag("OpenCart: Login API Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can log into account")]
        public void LoginPostRequest()
        {
            string api_token = @"aee1573e56e440106cbed4caf2";
            var client = new RestClient("http://localhost/index.php?route=api/login&api_token=" + api_token);
            var request = new RestRequest(Method.POST);
            
            request.AddParameter("username", "userApi");
            request.AddParameter("key", "F0oGxrtTiO4lGPWbZZ7oijZ2BYcRGNfxDo7O4auA2466zE12T4ho4R5wFYHlQhswhT2f87o8wuwZOmDuXsZ3dQg807TSLE8Bzbp0E11S4llzn2tHS2raobq8gBm8oevawpgF2u7ZHYCdWPbucFLRktwBk5ro6ovkG523gIddnIItaPFA8mExNN3PzIcjKgL15jGP8DxGlwvoWgprqDOoFxfWAtntKTP8RmyQmSDijLTUjyZrvvj5FqDnf7SohCaT");
            IRestResponse response = client.Execute(request);

            //Assert
            Assert.True(response.Content.Contains("Success: API session successfully started!"));
            Assert.AreEqual(true, response.IsSuccessful);
            Console.WriteLine(response.Content);

        }
    }
}
