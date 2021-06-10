using NUnit.Framework;
using RestSharp;
using System.Net;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace LV587SETOPENCART.Tests
{
    class SuccessResponse
    {
        public string success { get; set; }
    }
    class LoginResponse : SuccessResponse
    {
        public string api_token { get; set; }
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("VoucherAPITest")]
    [AllureDisplayIgnored]
    class VoucherAPITest
    {
        const string ApiKey = "IfG4hpYi00M7QyrfOihtgjaDbl10Ai1pQWlm28hYRMr8vZOgnZJFDly4BYtVxKZXdHKKEnozYaVrB2FlbHeEEud4tlJIIoWfUY5nayXAcae6Ckc343ULa03JrPUGnINfZv1fXlz8Fmo1PowyEggzbHcm0Ux56JJgPSAwGVLKS1poFKB6nBC4MSFSzcdFDSxHTmNTfdla5EpgmDE1KggdMVcP7JnqhXKono43ZBMKZZjqW0BoXtPNdKgfuQPucGYD";
        const string Username = "NEW";
        RestClient client;
        string token;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            client = new RestClient("http://40.76.251.6");
            RestRequest request = new RestRequest("index.php?route=api/login", Method.POST, DataFormat.Json);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", Username);
            request.AddParameter("key", ApiKey);
            IRestResponse<LoginResponse> response = client.Execute<LoginResponse>(request);
            token = response.Data.api_token;
        }

        [Test(Description = "Apply existing voucher")]
        [AllureTag("API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Tania Koretska")]
        public void ApplyExistingVoucher()
        {
            RestRequest request = new RestRequest($"index.php?route=api/voucher&api_token={token}", Method.POST, DataFormat.Json);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("voucher", "VOU-7271");

            IRestResponse<SuccessResponse> response = client.Execute<SuccessResponse>(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual("Success: Your gift voucher discount has been applied!", response.Data.success);
        }

        [Test(Description = "Add new voucher for current session")]
        [AllureTag("API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Tania Koretska")]
        public void AddVoucher()
        {
            RestRequest request = new RestRequest($"index.php?route=api/voucher/add&api_token={token}", Method.POST, DataFormat.Json);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("from_name", "Administator");
            request.AddParameter("from_email", "administrator@gmail.com");
            request.AddParameter("to_name", "Customer");
            request.AddParameter("to_email", "custom@gmail.com");
            request.AddParameter("amount", "100");
            request.AddParameter("code", "VOU-1234");

            IRestResponse<SuccessResponse> response = client.Execute<SuccessResponse>(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual("Success: You have modified your shopping cart!", response.Data.success);
        }
    }
}
