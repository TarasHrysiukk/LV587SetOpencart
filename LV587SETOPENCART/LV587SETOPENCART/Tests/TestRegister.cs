using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class TestRegister
    {
        
        [Test]
        public void TestRegisterNewUser()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Dsyhi\source\repos\asmnmsf\packages\Selenium.WebDriver.ChromeDriver.91.0.4472.1900\driver\win32");

            driver.Navigate().GoToUrl("http://localhost/index.php?route=common/home");

            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector(".list-inline > .dropdown > .dropdown-toggle")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector(".dropdown-menu.dropdown-menu-right > li > a")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Dima");

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Tester");

            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("aa@gmail.com");

            driver.FindElement(By.Name("telephone")).Clear();
            driver.FindElement(By.Name("telephone")).SendKeys("0679155137");

            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("qwerty");

            driver.FindElement(By.Name("confirm")).Clear();
            driver.FindElement(By.Name("confirm")).SendKeys("qwerty");

            driver.FindElement(By.Name("agree")).Click();

            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

            Thread.Sleep(1000);

            IWebElement actualText = driver.FindElement(By.CssSelector("#content > h1"));

            Thread.Sleep(1000);

            Assert.AreEqual("Your Account Has Been Created!", actualText.Text);

            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector("a.btn.btn-primary")).Click();

            Thread.Sleep(1000);

            IWebElement pageAccount = driver.FindElement(By.CssSelector("#content.col-sm-9 > h2:first-child"));

            Assert.AreEqual("My Account", pageAccount.Text);
        }
    }
}