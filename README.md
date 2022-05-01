# Project name : TFLCodeChallenge
## Pre-Requisites for project execution
- Visual Studio 2022
- Latest Chrome Driver version 99.0.4844.5100

## 01 - Automation Framework design Approach

###### IDE & Language
   - Visual Studio 2022 & C#
###### Automation Tool
   - Selenium WebDriver
###### Project Type
   - BDD-SpecFlow
###### Design Pattern
   - Singleton with POM
###### DataDriven
   - Scenario Outline
###### Reports
   - Extent Reports
###### Browsers
   - Chrome Driver
## 02 - Test Scenarios

- Scenario 1: I can plan my journey successfully	

- Scenario 2: I can not plan my journey without entering Source and Destinations	

- Scenario 3: I can not plan my journey with Invalid  Source and Destination locations

- Scenario 4: I can edit my journy details and preferences

- Scenario 5:  I can view My recent journey plans

 ## 03 - Brief Description about framework Approach
 - Reports created using ExtentReports and ScreenShots captured for failed scenarios
 
 - In Project solution 
     ###### 1. ObjectRepsitoryLibrary : 
      which contains common utilities, locators (defined in page classfiles), SingletonBaseclass 
       
    ###### 2. HelperLibrary : 
     which contains the methods which are specific to the respective pages
       
    ###### 4. BDDFramework(SpecFlow Project) 
       Feature files
       Stepdefination files
       Hooks

