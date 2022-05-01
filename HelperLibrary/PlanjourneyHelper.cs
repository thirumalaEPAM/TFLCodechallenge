using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectReporsitoryLibrary;

namespace HelperLibrary
{
    public class PlanjourneyHelper
    {
        IWebDriver webdriver;
        CommonUtility commonUtility;        
        public void planmyjourney(string fromplace,string toplace)
        {
                       
            commonUtility.SendText(PlnJourneyRepo.eltFromLocation, fromplace);
            commonUtility.SendText(PlnJourneyRepo.eltToLocation, toplace);


        }       

        public PlanjourneyHelper(IWebDriver driver) {
            this.webdriver = driver;
            commonUtility = new CommonUtility(webdriver);
        }
    }
}
