using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Tools
{
    class ProjectTools : ClassWithDriver
    {
        public ProjectTools(IWebDriver driver) : base(driver) { }
            public bool PriceCurrency(string unitPrice, string currency)
        {
            bool exist = false;
            Regex regex = new Regex(currency);
            MatchCollection matches = regex.Matches(unitPrice);
            if (matches.Count > 0) //by using RegularExpressions
            {
                exist = true;
            }
            return exist;
        }
    }
}
