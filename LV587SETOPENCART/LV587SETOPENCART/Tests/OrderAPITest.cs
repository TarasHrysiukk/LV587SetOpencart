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
    [AllureSuite("[Order]")]
    [AllureDisplayIgnored]
    class OrderAPITest
    {
        [Test]
        [AllureTag("OpenCart: OrderInfo Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Andrii Orlyk")]
        [Description("This test checks to if info exist in order")]
        public void OrderInfoPostRequest()
        {
            string api_token = @"34fa00953f334c81faafb58ae4";
            var client = new RestClient("http://localhost/index.php?route=api/order/info&api_token=" + api_token);
            var request = new RestRequest(Method.POST);

            request.AddParameter("username", "Andrew");
            request.AddParameter("key", "2v3qH88JpI8CZR3CEKofKIr05pjyt36AaSD1uMOiKt3RjYlo4DdpnE5FwRfXLt52y63BE0UyvIYOBwwhF7LEikBTYrCBiv5rlzzhCZfsdchcgm4AP5TOCfDqgZiqqyMpLeLS1TDatSMdfjA5ujFA15ZLAgYbmBafHmoZMk1TStpcRoZifInurt6DGLanNPLbZw7eQTxssRc3i7Ac4iPk3FODEofSy7iTSiyWIs3Ya3NFlfRK5ebyAbiLXHT30gQJ");
            IRestResponse response = client.Execute(request);
            string textRes = "Warning: Order could not be found!";

            Assert.True(response.Content.Contains(textRes));
            Assert.AreEqual(true, response.IsSuccessful);
            Console.WriteLine(response.Content);
        }
        [Test]
        [AllureTag("OpenCart: OrderAdd Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Andrii Orlyk")]
        [Description("This test checks to if info added order")]
        public void OrderAddPostRequest()
        {
            string api_token = @"34fa00953f334c81faafb58ae4";
            var client = new RestClient("http://localhost/index.php?route=api/order/add&api_token=" + api_token);
            var request = new RestRequest(Method.POST);

            request.AddParameter("username", "Andrew");
            request.AddParameter("key", "2v3qH88JpI8CZR3CEKofKIr05pjyt36AaSD1uMOiKt3RjYlo4DdpnE5FwRfXLt52y63BE0UyvIYOBwwhF7LEikBTYrCBiv5rlzzhCZfsdchcgm4AP5TOCfDqgZiqqyMpLeLS1TDatSMdfjA5ujFA15ZLAgYbmBafHmoZMk1TStpcRoZifInurt6DGLanNPLbZw7eQTxssRc3i7Ac4iPk3FODEofSy7iTSiyWIs3Ya3NFlfRK5ebyAbiLXHT30gQJ");
            IRestResponse response = client.Execute(request);
            string textRes = "Warning: Products marked with *** are not available in the desired quantity or not in stock!";

            Assert.True(response.Content.Contains(textRes));
            Assert.AreEqual(true, response.IsSuccessful);
            Console.WriteLine(response.Content);
        }
    }
}
