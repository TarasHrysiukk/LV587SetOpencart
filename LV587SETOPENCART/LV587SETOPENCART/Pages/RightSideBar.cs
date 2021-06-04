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
        public IWebElement MyAccountListButton { get { return driver.FindElement(By.CssSelector(".list-group > a[href*='account/account']")); } }
        public IWebElement PasswordListButton { get { return driver.FindElement(By.CssSelector(".list-group > a[href*='password']")); }  }
        public IWebElement AddressBookListButton { get { return driver.FindElement(By.CssSelector(".list-group > a[href*='address']")); } }
        public IWebElement LogoutListButton { get { return driver.FindElement(By.CssSelector(".list-group > a[href*='logout']")); } }
        public RightSideBar(IWebDriver driver) : base(driver)
        {
          
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
