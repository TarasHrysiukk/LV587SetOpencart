using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    public class ClassWithDriver
    {
        public IWebDriver driver;


        public IWebDriver Driver { get; private set; }


        public ClassWithDriver() { }

        public ClassWithDriver(IWebDriver driver)
        {
            this.driver = driver;   
        }

        public void NavigateToURL()
        {
            driver.Navigate().GoToUrl(@"http://localhost/");
        }

        //Method for different paths
        public void NavigateTo(string path)
        {
            driver.Navigate().GoToUrl(path);
        }

    }
}
