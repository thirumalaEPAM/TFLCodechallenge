using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectReporsitoryLibrary;
namespace HelperLibrary
{
    public class PageHelper
    {
        IWebDriver webdriver;

        CommonUtility Commonobj;       

        public void ButtonClick(By by)
        {
            Commonobj = new CommonUtility(webdriver);
            Commonobj.ClickElement(by);
        }
       public void selectValuefromDropdown(By by,string value)
        {
            Commonobj = new CommonUtility(webdriver);
            Commonobj.SelectValue(by,value);
        }
        public string getText(By by)
        {
            Commonobj = new CommonUtility(webdriver);
            return Commonobj.getElementText(by);
        }
        public void AcceptCookies() 
        {
            try
            {
                Commonobj = new CommonUtility(webdriver);
                Commonobj.pageScroll(PlnJourneyRepo.eltAcceptCookiesbtn);
                Commonobj.ClickElement(PlnJourneyRepo.eltAcceptCookiesbtn);                
                Commonobj.pageScrollandClick(PlnJourneyRepo.eltSaveCookies);
                Commonobj.ClickElement(PlnJourneyRepo.eltSaveCookies);
            }
            catch (Exception ex) 
            { 
            }

        }
        public int RondomNum()
        {

            Random rnd = new Random();

            return rnd.Next(200, 1000);
        }

        public String TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)webdriver).GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            string path = path1 + "\\Screenshots\\" + RondomNum() + ".png";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }


        public PageHelper(IWebDriver driver)
        {
            this.webdriver = driver;
        }

    }
   
    
}
