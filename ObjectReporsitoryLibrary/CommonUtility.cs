using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReporsitoryLibrary
{
    public class CommonUtility
    {
        IWebDriver webdriver;

        public IWebElement WaitForElement(By elt)
        {

            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(5));
            return wait.Until(X => X.FindElement(elt));
        }

        public String getElementText(By elt)
        {

            return WaitForElement(elt).Text.ToString();
        }

        public void SendText(By elt, String text)
        {

            WaitForElement(elt).SendKeys(text);

        }

        public void ClickElement(By elt)
        {
            WaitForElement(elt).Click();
        }

        public void pageScroll(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 250)", "");


        }

        public void SelectValue(By by,string value)
        {
            SelectElement sel = new SelectElement(WaitForElement(by));
            sel.SelectByText(value);

        }
        public void pageScrollandClick(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;            
            js.ExecuteScript("arguments[0].click();", webdriver.FindElement(elt));

        }
        public CommonUtility(IWebDriver driver) { this.webdriver = driver; }
    }
}
