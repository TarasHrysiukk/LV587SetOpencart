using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class RightSideBar : ClassWithDriver
    {
        // describe My account/ password/ address book/ logout
        //+ Click
        public IWebElement MyAccountListButton { get; private set; }
        public IWebElement PasswordListButton { get; private set; }
        public IWebElement AddressBookListButton { get; private set; }
        public IWebElement LogoutListButton { get; private set; }
        public RightSideBar(IWebDriver driver) : base(driver)
        {
            MyAccountListButton = driver.FindElement(By.CssSelector(".list-group > a[href*='account/account']"));
            PasswordListButton = driver.FindElement(By.CssSelector(".list-group > a[href*='password']"));
            AddressBookListButton = driver.FindElement(By.CssSelector(".list-group > a[href*='address']"));
            LogoutListButton = driver.FindElement(By.CssSelector(".list-group > a[href*='logout']"));
        }
        public void MyAccountListButtonClick()
        {
            MyAccountListButton.Click();
        }
        public void PasswordListButtonClick()
        {
            PasswordListButton.Click();
        }
        public void AddressBookListButtonClick()
        {
            AddressBookListButton.Click();
        }
        public void LogoutListButtonClick()
        {
            LogoutListButton.Click();
        }
    }
}
