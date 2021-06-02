using NUnit.Framework;
using OpenQA.Selenium;


namespace LV587SETOPENCART
{
    public class WishListTests
    {
        // private IWebDriver driver;
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
           //  driver = new ChromeDriver();
           //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [SetUp]
        public void Setup()
        {
           // driver.Navigate().GoToUrl(@"http://localhost/index.php?route=account/register");

        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
           // driver.Quit();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

