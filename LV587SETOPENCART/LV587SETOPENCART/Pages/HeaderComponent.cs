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

        private readonly By currencyDropdown = By.ClassName("#form-currency > div > button");
        private readonly By wishListDropdown = By.CssSelector("#wishlist-total > span");
        private readonly By shoppingCartLink = By.XPath("//html/body/nav/div/div[2]/ul/li[4]/a/span");
        private readonly By checkout = By.CssSelector("#top-links > ul > li:nth-child(5) > a > span");
        private readonly By shoppingCartBlackButton = By.CssSelector("#cart > button");
        private readonly By searchField = By.CssSelector("#search input");
        private readonly By searchButton = By.CssSelector("#search button");
        private readonly By myAccountButton = By.CssSelector("#top-links > ul > li.dropdown > a > span.hidden-xs.hidden-sm.hidden-md");
        private readonly By CartButtonLabel = By.CssSelector("#cart-total:not(.fa-shopping-cart)");

        public void CurrencyClickAndSelect(Currencies currency)
        {
            driver.FindElement(currencyDropdown).Click();
            
            switch (currency)
            {
                case Currencies.EUR:
                    driver.FindElement(By.Name("EUR")).Click();
                    break;

                case Currencies.GBP:
                    driver.FindElement(By.Name("GBP")).Click();
                    break;

                case Currencies.USD:
                    driver.FindElement(By.Name("USD")).Click();
                    break;

                default:
                    break;
            }
        }

        public void ClickOnWishList()
        {
            driver.FindElement(wishListDropdown).Click();
        }

        public void ClickOnShoppingCartLink()
        {
            driver.FindElement(shoppingCartLink).Click();
        }

        public void ClickOnCheckout()
        {
            driver.FindElement(checkout).Click();
        }
        public void ClickOnShoppingCartBlackButton()
        {
            driver.FindElement(shoppingCartBlackButton).Click();
        }
        public string CartButtonLabelText()
        {
            IWebElement search = driver.FindElement(CartButtonLabel);
            return search.Text;
        }

        public void ChooseCategory(CategoryMenu category)
        {
            switch (category)
            {
                case CategoryMenu.Desktops:
                    driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(1) > a")).Click();
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[1]/div/a")).Click();
                    break;
                case CategoryMenu.LaptopsAndNotebooks:
                    driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(2) > a")).Click();
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[2]/a")).Click();
                    break;
                case CategoryMenu.Components:
                    driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(3) > a")).Click();
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/a")).Click();
                    break;
                case CategoryMenu.Tablets:
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[4]/a")).Click();
                    break;
                case CategoryMenu.Software:
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[5]/a")).Click();
                    break;
                case CategoryMenu.PhonesAndPDAs:
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[6]/a")).Click();
                    break;
                case CategoryMenu.Cameras:
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[7]/a")).Click();
                    break;
                case CategoryMenu.MP3Players:
                    driver.FindElement(By.CssSelector("#menu > div.collapse.navbar-collapse.navbar-ex1-collapse > ul > li:nth-child(8) > a")).Click();
                    driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[8]/div/a")).Click();
                    break;
                default:
                    break;
            }
        }

        public void SelectSearch()
        {
            IWebElement search = driver.FindElement(searchField);
            search.Click();
        }

        public void SearchItem(string searchText)
        {
            IWebElement search = driver.FindElement(searchField);
            IWebElement button = driver.FindElement(searchButton);
            search.Clear();
            search.SendKeys(searchText);
            button.Click();
        }

        public void ClickOnMyAccount(MyAccountMenuActions action)
        {
            driver.FindElement(myAccountButton).Click();

            switch (action)
            {
                case MyAccountMenuActions.Register:
                    driver.FindElement(By.LinkText("Register")).Click();
                    break;
                case MyAccountMenuActions.Login:
                    driver.FindElement(By.LinkText("Login")).Click();
                    break;
                case MyAccountMenuActions.MyAccount:
                    driver.FindElement(By.LinkText("My Account")).Click();
                    break;
                case MyAccountMenuActions.Logout:
                    driver.FindElement(By.LinkText("Logout")).Click();
                    break;
                default:
                    break;
            }
        }

        public string GetCurrencyName(Currencies currency)
        {
            driver.FindElement(currencyDropdown).Click();

            switch (currency)
            {
                case Currencies.EUR:
                    return driver.FindElement(By.Name("EUR")).Text;
                    break;

                case Currencies.GBP:
                    return driver.FindElement(By.Name("GBP")).Text;
                    break;

                case Currencies.USD:
                    return driver.FindElement(By.Name("USD")).Text;
                    break;

                default:
                    return "no element";
                        break;
            }
        }
    }
}
