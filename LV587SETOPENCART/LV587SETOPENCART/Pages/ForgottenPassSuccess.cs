using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class ForgottenPassSuccess : ClassWithDriver
    {
        public IWebElement AlertMessage { get {return driver.FindElement(By.CssSelector(".alert-success:not(.fa-check-circle)")); } }
        public ForgottenPassSuccess(IWebDriver driver) : base(driver)
        {

            //AlertMessage = driver.FindElement(By.CssSelector(".alert-success:not(.fa-check-circle)"));
        }
        public string AlertMessageText()
        {
            return AlertMessage.Text;
        }
    }
}
