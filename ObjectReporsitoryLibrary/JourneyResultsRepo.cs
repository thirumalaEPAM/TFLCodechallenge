using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReporsitoryLibrary
{
    public class JourneyResultsRepo
    {
        public static By eltJourneypage = By.XPath("//span[text()='Journey results']");
        public static By eltFrom = By.XPath("//span[text()='From:']//following-sibling::span/strong");
        public static By eltTo = By.XPath("//span[text()='To:']//following-sibling::span/strong");
        public static By eltPublicTrans = By.XPath("//h2[text()='Fastest by public transport']");
        public static By eltCyclingandOther= By.XPath("//h2[text()='Cycling and other options']");
                
    }
}
