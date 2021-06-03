using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace LV587SETOPENCART.Pages
{
    class MyAccountPage : ClassWithDriver
    {
        public IWebElement textPageAccount { get; private set; }

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            IWebElement pageAccount = driver.FindElement(By.CssSelector("#content.col-sm-9 > h2:first-child"));

            Assert.AreEqual("My Account", pageAccount.Text);

        }

        // Click on add adress button
        public void ClickOnAddAdressButton()
        {
            addAdressButton.Click();
        }

        // Click on edit adress button
        public void ClickOnEditAdressButton()
        {
            editAdressButton.Click();
        }

        // Click on delete adress button
        public void ClickOnDeleteAdressButton()
        {
            deleteAdressButton.Click();
        }

        // Click on back button
        public void ClickOnBackButton()
        {
            backButton.Click();
        }

    }
}
