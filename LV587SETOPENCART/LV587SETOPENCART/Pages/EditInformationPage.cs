using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    class EditInformationPage : ClassWithDriver
    {
        public IWebElement FirstNameInput { get { return driver.FindElement(By.Name("firstname")); } }
        public IWebElement LastNameInput { get { return driver.FindElement(By.Name("lastname")); } }
        public IWebElement EmailInput { get { return driver.FindElement(By.Name("email")); } }
        public IWebElement TelephoneInput { get { return driver.FindElement(By.Name("telephone")); } }
        public IWebElement ButtonContinue { get { return driver.FindElement(By.CssSelector(".pull-right > .btn.btn-primary")); } }


        public EditInformationPage(IWebDriver driver) : base(driver) { }

        public void SetFirstNameInput(string text)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(text);
        }
        public void SetLastNameInput(string text)
        {
            LastNameInput.Clear();
            LastNameInput.SendKeys(text);
        }
        public void SetEmailInput(string text)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(text);
        }
        public void SetTelephoneInput(string text)
        {
            TelephoneInput.Clear();
            TelephoneInput.SendKeys(text);
        }
        public void ButtonClick()
        {
            ButtonContinue.Click();
        }
    }
}
