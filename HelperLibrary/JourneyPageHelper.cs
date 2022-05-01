using ObjectReporsitoryLibrary;
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
        CommonUtility commonUtility;

        public void UpdateJourneyPreferences(Dictionary<string,string>  dect) 
        {
            try
            {
               
                commonUtility.Mouseclick(PlnJourneyRepo.eltToLocation);
                commonUtility.ClickElement(JourneyResultsRepo.eltClearLocation);
                commonUtility.EnterLocations(PlnJourneyRepo.eltToLocation, dect["Destination"]);
                commonUtility.SelectValue(PlnJourneyRepo.eltDate, dect["JourneyDate"]);
                commonUtility.ClickElement(JourneyResultsRepo.eltEditPreference);
                commonUtility.ClickElement(JourneyResultsRepo.eltDeselectAllPref);
                if (dect["Bus"] == "true")
                {
                    commonUtility.pageScroll(JourneyResultsRepo.eltBusCheckbox);
                    commonUtility.Mouseclick(JourneyResultsRepo.eltBusCheckbox);
                }
                if (dect["Tram"] == "true")
                {
                    commonUtility.Mouseclick(JourneyResultsRepo.eltTramCheckbox);
                }
                commonUtility.pageScroll(JourneyResultsRepo.eltSavePref);
                commonUtility.pageScroll(JourneyResultsRepo.eltUpdateJourney);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        public Boolean ValidationJourneyResults() {
            Boolean flag=false;
            string result=string.Empty;
            try
            {
                result = commonUtility.getElementText(JourneyResultsRepo.eltCyclingandOther);
                if(result ==Constants.cyclingandOther) flag=true;
                else flag=false;

            }
            catch(Exception ex) 
            {
                result = commonUtility.getElementText(JourneyResultsRepo.eltFastTrans);
                if (result == Constants.fastestTrans) flag = true;

            }
            return flag; 
        }

        public Boolean validation(int dictCount,By by) 
        {
            int elementsCount=commonUtility.CountElements(by);
            
            Boolean flag =false;

            if(dictCount==elementsCount) flag= true;

            return flag;
        }
        public JourneyPageHelper(IWebDriver driver)
        {
            this.webdriver = driver;
            commonUtility = new CommonUtility(webdriver);
        }
    }
}
