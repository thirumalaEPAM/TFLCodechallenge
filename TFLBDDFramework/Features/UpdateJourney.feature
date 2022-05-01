﻿Feature: As a User I can Edit my Journey preferences and view my recent journey details

In This feature we can validate the Edit Journey scenario and view the recent journey list

@tag1
Scenario Outline: I can edit my journy details and preferences
	Given I can Launch TFL application and do my journey plan
	When I can click on Edit Journey button for change my journey details
	And I Change My preferences <Destination> <JourneyDate> <Bus>
	And I  Save the preferences and click on UpdateJourney button
    Then I can view my journey details updated successfully

Examples:
| Destination   | JourneyDate | Bus  |
| London Bridge | Stratford   | true |


Scenario:  I can view My recent journey plans
	Given I can Launch TFL application and do my journey plan
	When  I Navigate to Plan My Journey and click on Recents tab
	Then I can view the List of my Recent journey plans