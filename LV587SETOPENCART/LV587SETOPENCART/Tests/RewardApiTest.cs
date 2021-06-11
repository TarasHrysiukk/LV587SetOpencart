using NUnit.Framework;
using RestSharp;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("RewardApiTest")]
    [AllureDisplayIgnored]
    class RewardApiTest
    {
        [Test]
        [AllureTag("OpenCart:RewardApiTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user can get maximum amount of reward points")]
        public void ApiMaximumRewardTest()
        {
            //Arrange
            bool expected = true;
            
            //Act
            string apiToken = "3c95757112a2c528d41f961a7b";
            var client = new RestClient("http://localhost/index.php?route=api/reward/maximum&api_token=" + apiToken);
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            bool actual = response.IsSuccessful;

            //Assert
            Assert.AreEqual(expected, actual);
            Console.WriteLine(response.Content);

        }
    }
}
