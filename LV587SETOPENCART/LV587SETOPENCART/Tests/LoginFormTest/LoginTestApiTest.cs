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
        [AllureTag("OpenCart: Login Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can log into account")]
        public void CurrencyPostRequest()
        {
            string api_token = @"d574ca47547350d4466657ec2b";
            var client = new RestClient("http://localhost/index.php?route=api/login&api_token=" + api_token);
            var request = new RestRequest(Method.POST);
            
            request.AddParameter("username", "userApi");
            request.AddParameter("key", "ahKlTba67uuK87PUA5tb0DO1CejhrCEscMQid4QmsoFFqccYn6m2qKQ7mTG5f0i7ylhkEydznZtL6KUwsPPr4VBf0NDwRejr36J08K3Btyp4MrwvEJX3wPggLHjdby6fyHaOJSC81F6yIZX5bFvHhQ0kSnPboS7n5wiuBjTFmuP5UrqebW5oCcqJtTL0a7X4nyy1cK33RXTpXSAnQKO3OctXW8r7fZyFr6S7ROb5ZBY0KzLmEE1ToT1Tgv7F58rs");
            IRestResponse response = client.Execute(request);

            //Assert
            Assert.True(response.Content.Contains("Success"));
            Assert.AreEqual(true, response.IsSuccessful);
            Console.WriteLine(response.Content);

        }
    }
}
