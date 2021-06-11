using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using LV587SETOPENCART.Pages;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("MainPageSearchTest")]
    [AllureDisplayIgnored]
    class MainPageSearchTest
    {
        IWebDriver driver;
        HeaderComponent header;
        SearchCriteriaComponent searchCriteria;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(@"C:\chromedriver_win32");
            header = new HeaderComponent(driver);
            searchCriteria = new SearchCriteriaComponent(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void BeforeEachMethod()
        {
            driver.Navigate().GoToUrl("http://40.76.251.6/index.php?route=common/home");
        }

        [Test(Description = "Verify searching particular item from the homepage")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureTms("SETT-160")]
        [AllureOwner("Tania Koretska")]
        public void SearchItem()
        {
            header.SearchItem("Samsung SyncMaster 941BW");
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            
            Assert.AreEqual(1, searchCriteria.FoundProducts.Count); 
            Assert.NotNull(searchCriteria.FoundProducts[0].FindElement(By.LinkText("Samsung SyncMaster 941BW")));
        }

        [Test(Description = "Demonstrational test to show the screenshot capturing")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureTms("SETT-160")]
        [AllureOwner("Tania Koretska")]
        public void FailingTest()
        {
            header.SearchItem("Samsung SyncMaster 941BW");
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            string screenshotPath = @"C:\Users\user\source\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\screenshots\ScreenshotImageFormat.png";
            Screenshot failedTestScreen = ((ITakesScreenshot)driver).GetScreenshot();

            try
            {
                Assert.AreEqual(20, searchCriteria.FoundProducts.Count);
            }
            catch (Exception)
            {
                failedTestScreen.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("TearDown", "application/png", screenshotPath);
            }
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
