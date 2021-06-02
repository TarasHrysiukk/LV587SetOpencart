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

        public IWebElement FirstName { get; private set; }
        public IWebElement LastName { get; private set; }
        public IWebElement Company { get; private set; }
        public IWebElement AddressFirst { get; private set; }
        public IWebElement AddressSecond { get; private set; }
        public IWebElement City { get; private set; }
        public IWebElement PostCode { get; private set; }
        public IWebElement Country { get; private set; }  //drop down menu
        public IWebElement CountryValue { get; private set; }  
        public IWebElement Region{ get; private set; }  //drop down menu
        public IWebElement RegionValue { get; private set; } 
        public IWebElement DefoultAddressRadioButton { get; private set; }
        public IWebElement ContinueButton { get; private set; }
        public IWebElement BackButton { get; private set; }


        public AddEditAddress(IWebDriver driver) : base(driver) 
        {
            //First Name field
            FirstName = driver.FindElement(By.Id("input-firstname"));
            //Last Name field
            LastName = driver.FindElement(By.Id("input-lastname"));
            //Company Name field
            Company = driver.FindElement(By.Id("input-company"));
            //Addres-1  field
            AddressFirst = driver.FindElement(By.Id("input - address - 1"));
            //Addres-2  field
            AddressSecond = driver.FindElement(By.Id("input-address-2"));
            //Add City  field
            City = driver.FindElement(By.Id("input-city"));
            //Add Post Code  field
            PostCode = driver.FindElement(By.Id("input-postcode"));
            //add Countr
            Country = driver.FindElement(By.Id("input-country"));
            CountryValue = driver.FindElement(By.XPath("//select/option[@value='220']"));
            //add Region
            Region = driver.FindElement(By.Id("input-zone"));
            RegionValue = driver.FindElement(By.XPath("//select/option[@value='3493']"));
            //Radio Button  Defoult Address
            DefoultAddressRadioButton = driver.FindElement(By.CssSelector(".radio-inline input[value=\"0\"]"));
            //Button Continue
            ContinueButton = driver.FindElement(By.CssSelector(".pull-right input[type='submit']"));
            //Back button
            BackButton = driver.FindElement(By.CssSelector(".pull-left a[href*='/address']"));
        }

        public void AddNewAddres()
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

        public void EditAddres(IWebElement element,string text)
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
