using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    class AddressBook : ClassWithDriver
    {
        //add new address button click

        //edit address  button
        //delete address button
        //back button

        public IWebElement addAddressButton { get { return driver.FindElement(By.CssSelector(".clearfix .pull-right a[href*='/add']")); } }
        public IWebElement editAddressButton { get { return driver.FindElement(By.CssSelector(".table-responsive .table tbody tr td a.btn")); } }
        public IWebElement deleteAddressButton { get { return driver.FindElement(By.CssSelector(".table-responsive .table tbody tr td a:last-child")); } }
        public IWebElement backButton { get { return driver.FindElement(By.CssSelector(".pull-left a.btn")); } }
        public IWebElement addressBookButton { get { return driver.FindElement(By.CssSelector(".list-group a[href*='/address']")); } }
        public IWebElement alertMessage { get { return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }
        public AddressBook(IWebDriver driver) : base(driver) { }
        //Click on address button
        public void ClickOnAddressButton()
        {
            addressBookButton.Click();
        }
        // Click on add adress button
        public void ClickOnAddAdressButton()
        {
            addAddressButton.Click();
        }

        // Click on edit adress button
        public void ClickOnEditAdressButton()
        {
            editAddressButton.Click();
        }

        // Click on delete adress button
        public void ClickOnDeleteAdressButton()
        {
            deleteAddressButton.Click();
        }

        // Click on back button
        public void ClickOnBackButton()
        {
            backButton.Click();
        }

        public string GetAlertMessageText()
        {
            return alertMessage.Text;
        }
    }
}
