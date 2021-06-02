using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class ClassWithDriver
    {
        private IWebDriver driver;

        public IWebDriver Driver { get; private set; }

        public ClassWithDriver(IWebDriver driver)
        {
            this.driver = driver;   
        }
    }
}
