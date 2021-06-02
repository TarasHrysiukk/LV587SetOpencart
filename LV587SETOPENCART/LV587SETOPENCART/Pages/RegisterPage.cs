using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class RegisterPage: ClassWithDriver
    {
        //check if you not log NOW
        //Subscribe RadioButtons Click

        public IWebElement FirstNameInput { get { return driver.FindElement(By.Id("input-firstname")); } }
        public IWebElement LastNameInput { get { return driver.FindElement(By.Id("input-lastname")); } }
        public IWebElement EmailInput { get { return driver.FindElement(By.Id("input-email")); } }
        public IWebElement TelephoneInput { get { return driver.FindElement(By.Id("input-telephone")); } }
        public IWebElement PasswordInput { get { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement PasswordConfirmInput { get { return driver.FindElement(By.Id("input-confirm")); } }
        public IWebElement PrivacyPolicyCheckBox { get { return driver.FindElement(By.Name("agree")); } }
        public IWebElement SubscribeRadioButtonYES { get { return driver.FindElement(By.CssSelector(".radio-inline input[value='1']")); } }
        public IWebElement SubscribeRadioButtonNO { get { return driver.FindElement(By.CssSelector( ".radio-inline input[value='0']")); } }
        public IWebElement ConfirmButton { get { return driver.FindElement(By.CssSelector("input[type='submit']")); } }

        public RegisterPage(IWebDriver driver): base(driver){}


        // ATOMIC OPERATIONS 

        // FirstName TextBox
        public string GetFirstNameInputText()
        {
            return FirstNameInput.GetAttribute("value");
        }

        public void SetFirstNameInputTextAndClear(string text)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(text);
        }

        public void ClickFirstNameInput()
        {
            FirstNameInput.Click();
        }

        // LastName TextBox
        public string GetLastNameInputText()
        {
            return LastNameInput.GetAttribute("value");
        }
        public void SetLastNameInputTextAndClear(string text)
        {
            LastNameInput.Clear();
            LastNameInput.SendKeys(text);
        }

        public void ClickLastNameInput()
        {
            LastNameInput.Click();
        }

        // Email TextBox
        public string GetEmailInputText()
        {
            return EmailInput.GetAttribute("value");
        }

        public void SetEmailInputTextAndClear(string text)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(text);
        }

        public void ClickEmailInput()
        {
            EmailInput.Click();
        }

        // Telephone TextBox
        public string GetTelephoneInputText()
        {
            return TelephoneInput.GetAttribute("value");
        }

        public void SetTelephoneInputTextAndClear(string text)
        {
            TelephoneInput.Clear();
            TelephoneInput.SendKeys(text);
        }

        public void ClickTelephoneInput()
        {
            EmailInput.Click();
        }
        
        // Password TextBox
        public string GetPasswordInputText()
        {
            return PasswordInput.GetAttribute("value");
        }
        public void SetPasswordInputTextAndClear(string text)
        {            
            PasswordInput.Clear();
            PasswordInput.SendKeys(text);
        }

        public void ClickPasswordInput()
        {
            PasswordInput.Click();
        }

        // Password Confirm TextBox
        public string GetPasswordConfirmInputText()
        {
            return PasswordConfirmInput.GetAttribute("value");
        }

        public void SetPasswordConfirmInputTextAndClear(string text)
        {
            PasswordConfirmInput.Clear();
            PasswordConfirmInput.SendKeys(text);
        }

        public void ClickPasswordConfirmInput()
        {
            PasswordConfirmInput.Click();
        }

        // Confirm Button
        public void ClickConfirmButton()
        {
            ConfirmButton.Click();
        }

        //Privacy Policy CheckBox
        public void ClickPrivacyPolicyCheckBox()
        {
            PrivacyPolicyCheckBox.Click();
        }
    }
}
