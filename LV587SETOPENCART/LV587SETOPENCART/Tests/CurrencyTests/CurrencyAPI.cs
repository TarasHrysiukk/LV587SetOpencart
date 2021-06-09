using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Tests.CurrencyTests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [AllureNUnit]
    [AllureSuite("API")]
    [AllureDisplayIgnored]
    class CurrencyAPI
    {
        [Test]
        [AllureTag("OpenCart:CurrencyAPI")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("2")]
        [AllureTms("532")]
        [AllureOwner("V.Pfayfer")]
        public void CurrencyPostRequest()
        {
            string api_token = @"fcaff6fbba76c63ed68b4ce11a";
            var client = new RestClient(@"http://52.232.34.99/index.php?route=api/currency&api_token="+api_token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", "OCSESSID=4cb491b29061ef3ff0828e0217; currency=GBP; language=en-gb");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("currency", "GBP");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            //Assert
            Assert.True(response.Content.Contains("success"));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
