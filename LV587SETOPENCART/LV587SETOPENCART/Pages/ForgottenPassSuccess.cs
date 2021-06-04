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
        public IWebElement AlertMessage { get; private set; }
        public ForgottenPassSuccess(IWebDriver driver) : base(driver)
        {

            AlertMessage = driver.FindElement(By.CssSelector(".alert-success:not(.fa-check-circle)"));
        }
        public string AlertMessageText()
        {
            return AlertMessage.Text;
        }
    }
}
