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
            Commonobj.ClickElement(by);
        }
        public void waitforpageLoad()
        {
            System.Threading.Thread.Sleep(15000);
        }

        public void ButtonClick1(By by)
        {            
            Commonobj.ClickListWebElements(by);
        }
        public void pageScrollUp()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, -350)", "");

        }
        public void pageScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 300)", "");

        }
        public void SendText(By by,string text)
        {
            
            Commonobj.SendText(by,text);
        }
        public void selectValuefromDropdown(By by,string value)
        {
            
            Commonobj.SelectValue(by,value);
        }
        public string getText(By by)
        {
           
            return Commonobj.getElementText(by);
        }        
        public string LeavingDateConversion(string date)
        {                       
            string result = string.Empty;

            string[] strArr=date.Split(' ');

            result= strArr[0].Substring(0,3)+" "+ strArr[1].Substring(0, 2)+" "+ strArr[2].Substring(0, 3);

            return result;
        
        }
        public void AcceptCookies() 
        {
            try
            {
                
                Commonobj.pageScroll(PlnJourneyRepo.eltAcceptCookiesbtn);
                Commonobj.ClickElement(PlnJourneyRepo.eltAcceptCookiesbtn);                
                Commonobj.pageScrollandClick(PlnJourneyRepo.eltSaveCookies);
                Commonobj.ClickElement(PlnJourneyRepo.eltSaveCookies);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }

        }
        public string RondomNum()        {
            
            string datetime = DateTime.Now.ToString();
            return datetime.Replace("/", "").Replace(":", "");
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
            Commonobj = new CommonUtility(webdriver);
        }

    }
   
    
}
