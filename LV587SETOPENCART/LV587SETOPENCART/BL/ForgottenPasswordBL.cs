using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using System;

namespace LV587SETOPENCART.BL
{
    class ForgottenPasswordBL : ClassWithDriver
    {
        ForgottenPasswordPage forgottenPasswordPage;
        //LoginPage loginPage;
        public ForgottenPasswordBL(IWebDriver driver): base(driver)
        {
            //loginPage = new LoginPage(driver);
            forgottenPasswordPage = new ForgottenPasswordPage(driver);
        }

        public void ForgottenPassword(string email)
        {
            forgottenPasswordPage.ForgotPasswordEmail(email);
            forgottenPasswordPage.ClickOnContinueButton();
        }
    }
}
