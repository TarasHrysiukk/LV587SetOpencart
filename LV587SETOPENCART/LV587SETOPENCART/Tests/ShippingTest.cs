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

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[Shipping]")]
    [AllureDisplayIgnored]
    class ShippingTest
    {
        [Test]
        [AllureTag("OpenCart: Shipping methods Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vlad Vozniuk")]
        [Description("This test checks to if we have data from our request.")]
        public void ShippingPostRequest()
        {
            string api_token = @"a03294844811e8137c70f34d16";
            var client = new RestClient("http://localhost/index.php?route=api/shipping/methods&api_token=" + api_token);
            var request = new RestRequest(Method.POST);

            request.AddParameter("username", "Vlad");
            request.AddParameter("key", "qKhK6vej0vQAhbPVSMGT83IS6eDuLcZ0xVjCppsKckNY7JUFWI2IzomNw6TzIzcGILqO7cAgiin2SJERFEVoeM5vEgFI7VWmdDJiA4L5Hv7p8e70wDDqiOQgIM6jKGcVo4scwuDyE0VLwYGKhUPQnIVkY8oyqKTD8RYwrFBhwwC7OltFNKVo2CKQYD54EkYL5fZbvhLhuD7S66QgN4FNKot0HZaZ2WO8hmMOLwm7rWSXtJYxP8Zu0FQDuReXnRSo");
            IRestResponse response = client.Execute(request);
            string textRes = "[]";

            Assert.True(response.Content.Contains(textRes));
            Assert.AreEqual(true, response.IsSuccessful);
        }
    }
}
