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
    class LoginTestApiTest
    {
        [Test]
        public void CurrencyPostRequest()
        {
            string api_token = @"d574ca47547350d4466657ec2b";
            var client = new RestClient("http://localhost/index.php?route=api/login&api_token=" + api_token);
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", "userApi");
            request.AddParameter("key", "mRjNINV5kCI0WMq6NhODkVEx7oYwn5P251aj0t6P0Dw3IBmpuUs6qfnCqhjtkhzhKIo1GDcXoNVsl7TkWo7L7gw6SYDNyU7eCXZuVLmd4SHcOdNzH2adEHtxuMpoNi5zLSjBKZPNCFGtRjIITlLpOCRfuNsxzklUN6MMcp4GYS4Docr5ACQQQiEB5dAFW0Wre5bTLKgmnEJt53JACgSmMwXs4MBPP7AsLDfDT6M0K2dEbhrmKN4jNhWXF3znmV3o");
            IRestResponse response = client.Execute(request);
            //Assert
            Assert.True(response.Content.Contains("success"));
            Assert.AreEqual(true, response.IsSuccessful);
        }
    }
}
