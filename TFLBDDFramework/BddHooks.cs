﻿using TechTalk.SpecFlow;
using ObjectReporsitoryLibrary;
using HelperLibrary;
using OpenQA.Selenium;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

namespace TFLBDDFramework
{
    [Binding]
    public sealed class BddHooks
    {
        #region All Page Objects
        public static IWebDriver driver;
        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentTest Feature;
        private static ExtentTest Sceanrio;
        public static PageHelper help;
        public static PlanjourneyHelper planjourneyHelper;
        #endregion

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            SingletonBaseClass.setSingletonInstanceNull();
            driver = SingletonBaseClass.getDriverInstance().getDriver();
            SingletonBaseClass.getDriverInstance().launchBrowser();           
            help=new PageHelper(driver);
            planjourneyHelper = new PlanjourneyHelper(driver);
            help.AcceptCookies();
            Sceanrio = Feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            string path = path1 + "\\ExtentReports.html";
            var htmlreporter = new ExtentHtmlReporter(path);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreporter);
        }

        [AfterTestRun]
        public static void CleanupReport()
        {
            extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeatureAttribute()
        {

            Feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }
        [AfterStep]
        public static void AfterStepAttribute()
        {
            // help = new HelperClass(driver);
            var StepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (StepType == Constants.given) { Sceanrio.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text); }
                else if (StepType == Constants.when) { Sceanrio.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text); }
                else { Sceanrio.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text); }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (StepType == Constants.given)
                {
                    Sceanrio.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    Sceanrio.AddScreenCaptureFromPath(help.TakeScreenshot());
                }

                else if (StepType == Constants.when)
                {
                    Sceanrio.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    Sceanrio.AddScreenCaptureFromPath(help.TakeScreenshot());
                }
                else
                {

                    Sceanrio.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    Sceanrio.AddScreenCaptureFromPath(help.TakeScreenshot());

                }
            }

        }
        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver = null;

        }
    }
}