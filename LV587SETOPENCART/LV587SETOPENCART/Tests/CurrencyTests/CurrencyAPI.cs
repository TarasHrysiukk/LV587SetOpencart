using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Tests.CurrencyTests
{
    [TestFixture]
    class CurrencyAPI
    {
        [Test]
        public void CurrencyPostRequest()
        {
            string api_token = @"e45cf5cfaa9f60f7bcf8becce4";
            var client = new RestClient(@"http://52.232.34.99/index.php?route=api/currency&api_token="+api_token);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", "OCSESSID=4cb491b29061ef3ff0828e0217; currency=GBP; language=en-gb");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("currency", "GBP");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            //Assert
            Assert.True(response.Content.Contains("success"));
            Assert.AreEqual(true, response.IsSuccessful);
        }
    }
}
