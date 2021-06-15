using Allure.Commons;
using LV587SETOPENCART.BL;
using LV587SETOPENCART.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[AddressBook]")]
    [AllureDisplayIgnored]
    class AddressBookTest
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
            ClassWithDriver classWithDriver = new ClassWithDriver(driver);
            classWithDriver.NavigateToURL();
        }

        [Test]
        [AllureTag("OpenCart: NewAddress Book Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Andrii Orlyk")]
        [Description("This test checks to if address book was added")]
        public void NewAddressBookTest()
        {

            HeaderComponent headerComponent = new HeaderComponent(driver);
            AddEditAddress addEditAddress = new AddEditAddress(driver);
            AddressBook addressBook = new AddressBook(driver);
            LoginBL loginBL = new LoginBL(driver);

            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            addressBook.ClickOnAddressButton();
            addressBook.ClickOnAddAdressButton();
            addEditAddress.AddNewAddress();

            var actual = addressBook.GetAlertMessageText();

            Assert.IsTrue(actual.Contains("Your address has been successfully added"));
        }

        [Test]
        [AllureTag("OpenCart: DeleteAddress Book Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Andrii Orlyk")]
        [Description("This test checks to if address book was deleted")]
        public void DeleteAddressBookTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            AddressBook addressBook = new AddressBook(driver);
            LoginBL loginBL = new LoginBL(driver);

            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            addressBook.ClickOnAddressButton();
            addressBook.ClickOnDeleteAdressButton();
            var actual = addressBook.GetAlertMessageText();

            Assert.IsTrue(actual.Contains("Your address has been successfully deleted"));
        }

        [Test]
        [AllureTag("OpenCart: EditAddress Book Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Andrii Orlyk")]
        [Description("This test checks to if address book was deleted")]
        public void EditAddressBookTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            LoginBL loginBL = new LoginBL(driver);
            AddEditAddress addEditAddress = new AddEditAddress(driver);
            AddressBook addressBook = new AddressBook(driver);

            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            addressBook.ClickOnAddressButton();
            addressBook.ClickOnEditAdressButton();
            addEditAddress.SetCity("Kiev");
            addEditAddress.Continue();

            var actual = addressBook.GetAlertMessageText();

            Assert.IsTrue(actual.Contains("Your address has been successfully updated"));
        }
    }
}
