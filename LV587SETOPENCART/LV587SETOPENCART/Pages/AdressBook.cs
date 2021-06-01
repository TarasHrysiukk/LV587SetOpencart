using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    class AdressBook : ClassWithDriver
    {
        //add new address button click

        //edit address  button
        //delete address button
        //back button

        public IWebElement addAdressButton { get; private set; }
        public IWebElement editAdressButton { get; private set; }
        public IWebElement deleteAdressButton { get; private set; }
        public IWebElement backButton { get; private set; }

        public AdressBook(IWebDriver driver) : base(driver)
        {
            addAdressButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            editAdressButton = driver.FindElement(By.CssSelector("a.btn.btn-info"));
            deleteAdressButton = driver.FindElement(By.CssSelector("a.btn.btn-danger"));
            backButton = driver.FindElement(By.CssSelector("a.btn.btn-default"));
            
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
