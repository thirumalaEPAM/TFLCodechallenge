using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class JourneyPageHelper
    {
        IWebDriver webdriver;

        public JourneyPageHelper(IWebDriver driver){this.webdriver = driver;}
    }
}
