using NUnit.Framework;
using System.Threading;
using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using RestSharp;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class CuponAPITests
    {
        [Test]
        public void CouponPostRequestTest()
        {
            string api_token = @"2e1ce6bbf52f8caaab85c27585";
            var client = new RestClient(@"http://localhost/index.php?route=api/coupon&api_token=" + api_token);
            
            var request = new RestRequest(Method.POST); 
            request.AlwaysMultipartFormData = true;

            request.AddParameter("coupon","2222");
            IRestResponse response = client.Execute(request);
            
            Assert.True(response.Content.Contains("success"));
            Assert.AreEqual(true, response.IsSuccessful);
        }
    }
}
