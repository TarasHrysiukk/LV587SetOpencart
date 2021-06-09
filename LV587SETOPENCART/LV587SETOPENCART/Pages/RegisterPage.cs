using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class RegisterPage : ClassWithDriver
    {
        //check if you not log NOW
        //Subscribe RadioButtons Click

        public IWebElement FirstNameInput { get { return driver.FindElement(By.Name("firstname")); } }
        public IWebElement LastNameInput { get { return driver.FindElement(By.Name("lastname")); } }
        public IWebElement EmailInput { get { return driver.FindElement(By.Name("email")); } }
        public IWebElement TelephoneInput { get { return driver.FindElement(By.Name("telephone")); } }
        public IWebElement PasswordInput { get { return driver.FindElement(By.Name("password")); } }
        public IWebElement PasswordConfirmInput { get { return driver.FindElement(By.Name("confirm")); } }
        public IWebElement PrivacyPolicyCheckBox { get { return driver.FindElement(By.Name("agree")); } }
        public IWebElement SubscribeRadioButtonYES { get { return driver.FindElement(By.CssSelector(".radio-inline input[value='1']")); } }
        public IWebElement SubscribeRadioButtonNO { get { return driver.FindElement(By.CssSelector(".radio-inline input[value='0']")); } }
        public IWebElement ConfirmButton { get { return driver.FindElement(By.CssSelector("input[type='submit']")); } }
        public IWebElement GeneralWarningMessageReg { get { return driver.FindElement(By.CssSelector("div.alert.alert-danger.alert-dismissible")); } }
        public IWebElement EmailWarningMessage { get { return driver.FindElement(By.CssSelector("div.text-danger:first")); } }
        public IWebElement PasswordWarningMessage { get { return driver.FindElement(By.CssSelector("div.text-danger:second")); } }
        
        public RegisterPage(IWebDriver driver) : base(driver) { }


        // ATOMIC OPERATIONS 

        // FirstName TextBox
        

        public void SetFirstNameInputTextAndClear(string text)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(text);
        }

        // LastName TextBox

        public void SetLastNameInputTextAndClear(string text)
        {
            LastNameInput.Clear();
            LastNameInput.SendKeys(text);
        }

        // Email TextBox

        public void SetEmailInputTextAndClear(string text)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(text);
        }

        // Telephone TextBox

        public void SetTelephoneInputTextAndClear(string text)
        {
            TelephoneInput.Clear();
            TelephoneInput.SendKeys(text);
        }


        // Password TextBox
 
        public void SetPasswordInputTextAndClear(string text)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(text);
        }

        // Password Confirm TextBox


        public void SetPasswordConfirmInputTextAndClear(string text)
        {
            PasswordConfirmInput.Clear();
            PasswordConfirmInput.SendKeys(text);
        }

        // Confirm Button
        public void ClickConfirmButton()
        {
            ConfirmButton.Click();
        }
        public void ClickSubscribeRadioButton()
        {
            SubscribeRadioButtonYES.Click();
        }
        //Privacy Policy CheckBox
        public void ClickPrivacyPolicyCheckBox()
        {
            PrivacyPolicyCheckBox.Click();
        }
        public string VerifyGeneralExeptionRegText()
        {
            return GeneralWarningMessageReg.Text;
        }
        public string VerifyExeptionPasswordText()
        {
            return PasswordWarningMessage.Text;
        }
        public string VerifyExeptionEmailText()
        {
            return EmailWarningMessage.Text;
        }
    }
}
