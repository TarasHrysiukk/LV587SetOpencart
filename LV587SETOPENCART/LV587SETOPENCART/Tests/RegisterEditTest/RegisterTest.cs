using System;
using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;
using System.Threading;
namespace LV587SETOPENCART.Tests
    
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[Register] Create new customer Test")]
    [AllureDisplayIgnored]
    class RegisterTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(@"http://localhost/");
        }

        [Test]
        [AllureTag("OpenCart: Register Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukhii Dmitro")]
        [Description("The test check that you can create new customer account (Registration)")]
        public void RegisterPageTest()
        {
            // Click on My Account > Register
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Register);

            Thread.Sleep(1000);//only for presentation

            // Execute all test methods for fill in the fields
            RegisterPage registerPage = new RegisterPage(driver);
            registerPage.SetFirstNameInputTextAndClear("Dima");
            registerPage.SetLastNameInputTextAndClear("Sukhii");
            registerPage.SetEmailInputTextAndClear("test@gmail.com");
            registerPage.SetTelephoneInputTextAndClear("0930020102");
            registerPage.SetPasswordInputTextAndClear("qwerty12345678");
            registerPage.SetPasswordConfirmInputTextAndClear("qwerty12345678");
            Thread.Sleep(1000);//only for presentation
            registerPage.ClickPrivacyPolicyCheckBox();
            Thread.Sleep(1000);//only for presentation
            registerPage.ClickSubscribeRadioButton();
            Thread.Sleep(1000);//only for presentation
            registerPage.ClickConfirmButton();
            Thread.Sleep(1000);//only for presentation

            // verify that user has been create
            string expResUserCreated = "Your Account Has Been Created!";

            AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);

            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();

            try
            {
                Assert.AreEqual(expResUserCreated, accountCreatedPage.AccountCreatedText());
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\MyAccount.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\MyAccount.Png");
            }

            

            Thread.Sleep(1000);//only for presentation

            accountCreatedPage.ClickOnButtonContinue();

            Thread.Sleep(1000);//only for presentation

            // verify that page 'My Account' has been open
            string expResMyAccountPage = "My Account";

            MyAccountPage myAccountPage = new MyAccountPage(driver);
            
            
            try
            {
                Assert.AreEqual(expResMyAccountPage, myAccountPage.MyAccountText());
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\MyAccount.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\MyAccount.Png");
            }

            Thread.Sleep(1000);//only for presentation


        }

    }
}
