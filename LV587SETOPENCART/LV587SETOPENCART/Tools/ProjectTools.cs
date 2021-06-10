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
        public ProjectTools() { }
        public ProjectTools(IWebDriver driver) : base(driver) { }
        //Method with string where we check if it contains some character  
            public bool PriceCurrency(string StringWithCharacters, string character)
        {
            bool exist = false;
            Regex regex = new Regex(character);
            MatchCollection matches = regex.Matches(StringWithCharacters);
            if (matches.Count > 0) //by using RegularExpressions
            {
                exist = true;
            }
            return exist;
        }
    }
}
