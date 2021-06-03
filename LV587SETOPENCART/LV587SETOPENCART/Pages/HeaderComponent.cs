using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    enum Currencies
    {
        EUR = 1,
        GBP,
        USD
    }

    enum CategoryMenu
    {
        Desktops = 1,
        LaptopsAndNotebooks,
        Components,
        Tablets,
        Software,
        PhonesAndPDAs,
        Cameras,
        MP3Players
    }

    enum MyAccountMenuActions
    {
        Register,
        Login,
        MyAccount,
        Logout
    }

    class HeaderComponent : ClassWithDriver
    {
        public HeaderComponent() { }
        public HeaderComponent(IWebDriver driver) : base(driver){}

        private readonly By currencyDropdown = By.ClassName(".btn-group");
        private readonly By currencyName = By.CssSelector(".currency-select .btn .btn-link .btn-block");
        private readonly By wishListDropdown = By.CssSelector("#wishlist-total > span");
        private readonly By shoppingCartLink = By.XPath("//html/body/nav/div/div[2]/ul/li[4]/a/span");
        private readonly By checkout = By.CssSelector("#top-links > ul > li:nth-child(5) > a > span");
        private readonly By shoppingCartBlackButton = By.CssSelector("#cart > button");
        private readonly By searchField = By.CssSelector(".form-control .input-lg");
        private readonly By searchButton = By.CssSelector(".btn .btn-default .btn-lg");
        private readonly By myAccountButton = By.CssSelector("#top-links > ul > li.dropdown > a > span.hidden-xs.hidden-sm.hidden-md");
        private readonly By CartButtonLabel = By.CssSelector("#cart-total:not(.fa-shopping-cart)");

        public void CurrencyClickAndSelect(Currencies currency)
        {
            Driver.FindElement(currencyDropdown).Click();
            
            switch (currency)
            {
                case Currencies.EUR:
                    Driver.FindElement(By.Name("EUR")).Click();
                    break;

                case Currencies.GBP:
                    Driver.FindElement(By.Name("GBP")).Click();
                    break;

                case Currencies.USD:
                    Driver.FindElement(By.Name("USD")).Click();
                    break;

                default:
                    break;
            }
        }

        public void ClickOnWishList()
        {
            Driver.FindElement(wishListDropdown).Click();
        }

        public void ClickOnShoppingCartLink()
        {
            Driver.FindElement(shoppingCartLink).Click();
        }

        public void ClickOnCheckout()
        {
            Driver.FindElement(checkout).Click();
        }
        public void ClickOnShoppingCartBlackButton()
        {
            Driver.FindElement(shoppingCartBlackButton).Click();
        }
        public string CartButtonLabelText()
        {
            IWebElement search = Driver.FindElement(CartButtonLabel);
            return search.Text;
        }

        public void ChooseCategory(CategoryMenu category)
        {
            switch (category)
            {
                case CategoryMenu.Desktops:
                    Driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(1) > a")).Click();
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[1]/div/a")).Click();
                    break;
                case CategoryMenu.LaptopsAndNotebooks:
                    Driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(2) > a")).Click();
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[2]/a")).Click();
                    break;
                case CategoryMenu.Components:
                    Driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(3) > a")).Click();
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/a")).Click();
                    break;
                case CategoryMenu.Tablets:
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[4]/a")).Click();
                    break;
                case CategoryMenu.Software:
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[5]/a")).Click();
                    break;
                case CategoryMenu.PhonesAndPDAs:
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[6]/a")).Click();
                    break;
                case CategoryMenu.Cameras:
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[7]/a")).Click();
                    break;
                case CategoryMenu.MP3Players:
                    Driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(8) > a")).Click();
                    Driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[8]/div/a")).Click();
                    break;
                default:
                    break;
            }
        }

        public void SelectSearch()
        {
            IWebElement search = Driver.FindElement(searchField);
            search.Click();
        }

        public void SearchItem(string searchText)
        {
            IWebElement search = Driver.FindElement(searchField);
            search.Clear();
            search.SendKeys(searchText);
            search.Submit();
        }

        public void ClickOnMyAccount(MyAccountMenuActions action)
        {
            Driver.FindElement(myAccountButton).Click();

            switch (action)
            {
                case MyAccountMenuActions.Register:
                    Driver.FindElement(By.LinkText("Register")).Click();
                    break;
                case MyAccountMenuActions.Login:
                    Driver.FindElement(By.LinkText("Login")).Click();
                    break;
                case MyAccountMenuActions.MyAccount:
                    Driver.FindElement(By.LinkText("My Account")).Click();
                    break;
                case MyAccountMenuActions.Logout:
                    Driver.FindElement(By.LinkText("Logout")).Click();
                    break;
                default:
                    break;
            }
        }
    }
}
