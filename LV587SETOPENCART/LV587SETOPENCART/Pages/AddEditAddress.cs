using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class AddEditAddress : ClassWithDriver
    {
        //describe all component (add FirstName and Click...)
        //button continue (return address book)
        //button back (return my account)

        public IWebElement FirstName { get { return driver.FindElement(By.Id("input-firstname")); }  }
        public IWebElement LastName { get { return driver.FindElement(By.Id("input-lastname")); } }
        public IWebElement Company { get { return driver.FindElement(By.Id("input-company")); } }
        public IWebElement AddressFirst { get { return driver.FindElement(By.Id("input-address-1")); } }
        public IWebElement AddressSecond { get { return driver.FindElement(By.Id("input-address-2")); } }
        public IWebElement City { get { return driver.FindElement(By.Id("input-city")); } }
        public IWebElement PostCode { get { return driver.FindElement(By.Id("input-postcode")); } }
        public IWebElement Country { get { return driver.FindElement(By.Id("input-country")); } }  
        public IWebElement CountryValue { get { return driver.FindElement(By.XPath("//select/option[@value='220']")); } }  
        public IWebElement Region{ get { return driver.FindElement(By.Id("input-zone")); } }  
        public IWebElement RegionValue { get { return driver.FindElement(By.XPath("//select/option[@value='3493']")); } } 
        public IWebElement DefoultAddressRadioButton { get { return driver.FindElement(By.CssSelector(".radio-inline input[value=\"0\"]")); } }
        public IWebElement ContinueButton { get { return driver.FindElement(By.CssSelector(".pull-right input[type='submit']")); } }
        public IWebElement BackButton { get { return driver.FindElement(By.CssSelector(".pull-left a[href*='/address']")); } }
        public void SetFirstName(string text)
        {
            FirstName.Clear();
            FirstName.SendKeys(text);
        }
        public void SetLastName(string text)
        {
            LastName.Clear();
            LastName.SendKeys(text);
        }
        public void SetCompany(string text)
        {
            Company.Clear();
            Company.SendKeys(text);
        }
        public void SetAddressFirst(string text)
        {
            AddressFirst.Clear();
            AddressFirst.SendKeys(text);
        }
        public void SetAddressSecond(string text)
        {
            AddressSecond.Clear();
            AddressSecond.SendKeys(text);
        }
        public void SetCity(string text)
        {
            City.Clear();
            City.SendKeys(text);
        }
        public void SetPostCode(string text)
        {
            PostCode.Clear();
            PostCode.SendKeys(text);
        }
        public void SetCountry(string text)
        {
            Country.Clear();
            Country.SendKeys(text);
        }
        public void SetCountryValue(string text)
        {
            CountryValue.Clear();
            CountryValue.SendKeys(text);
        }
        public void SetRegion(string text)
        {
            Region.Clear();
            Region.SendKeys(text);
        }
        public void SetRegionValue(string text)
        {
            RegionValue.Clear();
            RegionValue.SendKeys(text);
        }
        public void SetDefoultAddressRadioButton(string text)
        {
            DefoultAddressRadioButton.Clear();
            DefoultAddressRadioButton.SendKeys(text);
        }
        public void Continue()
        {
            ContinueButton.Click();
        }
        public AddEditAddress(IWebDriver driver) : base(driver) { }

        public void AddNewAddress()
        {
            //Input First Name
            FirstName.Clear();
            FirstName.SendKeys("UserFirstName");
            //Input First Name
            LastName.Clear();
            LastName.SendKeys("UserLastName");
            //Input Company Name
            Company.Clear();
            Company.SendKeys("CompanyName");
            //Address-1
            AddressFirst.Clear();
            AddressFirst.SendKeys("SomeAddress1");
            //Address2
            AddressSecond.Clear();
            AddressSecond.SendKeys("SomeAdress2");
            //City
            City.Clear();
            City.SendKeys("Lviv");
            //Post Code
            PostCode.Clear();
            PostCode.SendKeys("79024");
            //Country
            Country.Click();
            CountryValue.Click();
            //Regio
            Region.Click();
            RegionValue.Click();
            //Radio button (Defolt Address) NO
            DefoultAddressRadioButton.Click();
            //Continue button
            ContinueButton.Click();
        }

        public void EditAddress(IWebElement element,string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void BackButtonClick()
        {
            BackButton.Click();

        }
    }
}
