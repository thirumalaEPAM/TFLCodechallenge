using System;
using TechTalk.SpecFlow;
using ObjectReporsitoryLibrary;
using NUnit.Framework;

namespace TFLBDDFramework.StepDefinitions
{
    [Binding]
    public class PlanMyJourneyStepDefinitions
    {
        string Source=string.Empty;
        string Destination=string.Empty;
        [Given(@"I can enter valid (.*) and (.*)")]
        public void GivenICanEnterValidAnd(string source, string destination)
        {
            Source=source;
            Destination=destination;
            BddHooks.planjourneyHelper.planmyjourney(source, destination);
        }

        [Given(@"I launched TFL portal and Enter Journey Time without  giving the source and destions")]
        public void GivenILaunchedTFLPortalAndEnterJourneyTimeWithoutGivingTheSourceAndDestions()
        {
            BddHooks.help.ButtonClick(PlnJourneyRepo.eltChangeTime);
            BddHooks.help.selectValuefromDropdown(PlnJourneyRepo.eltDate,Constants.journeyDate);            
        }

        [Given(@"I launch TFL portal and Enter Invalid Source and Destination As ""([^""]*)"" and ""([^""]*)""")]
        public void GivenILaunchTFLPortalAndEnterInvalidSourceAndDestinationAsAnd(string xXX, string yYY)
        {
            BddHooks.planjourneyHelper.planmyjourney(xXX, yYY);

        }


        [When(@"I can click on PlanMyJourney button")]
        public void WhenICanClickOnPlanMyJourneyButton()
        {
            BddHooks.help.ButtonClick(PlnJourneyRepo.eltPlanMyJourneybtn);
            BddHooks.help.waitforpageLoad();
        }

        [Then(@"I can view ""([^""]*)""")]
        public void ThenICanView(string p0)
        {
           string journeyresultsTxt= BddHooks.help.getText(JourneyResultsRepo.eltJourneypage);
           string fromPlace= BddHooks.help.getText(JourneyResultsRepo.eltFrom);
           string toPlace= BddHooks.help.getText(JourneyResultsRepo.eltTo);           
           Assert.AreEqual(p0, journeyresultsTxt);
           Assert.AreEqual(Source, fromPlace);
           Assert.AreEqual(Destination, toPlace);
           Assert.IsTrue(BddHooks.journeyPageHelper.ValidationJourneyResults());            
        }
        
        [Then(@"I can view  monadatory fields validations on From and To fields")]
        public void ThenICanViewMonadatoryFieldsValidationsOnFromAndToFields()
        {
            string fromValidation=BddHooks.help.getText(PlnJourneyRepo.eltFromvalidation);
            string toValidation = BddHooks.help.getText(PlnJourneyRepo.eltTovalidation);
            Assert.AreEqual(Constants.fromFieldValidation, fromValidation);
            Assert.AreEqual(Constants.toFieldValidation, toValidation); 
        }        

        [Then(@"I can not view the Journey results")]
        public void ThenICanNotViewTheJourneyResults()
        {
            string validationError = BddHooks.help.getText(PlnJourneyRepo.eltValidationError);
            Assert.AreEqual(Constants.InvalidJourneyerror,validationError);
        }


    }
}
