Feature: Tickets Service
	In order to return ticket records from the Autotask API
	As an API developer
	I want to understand the tickets service

@ticket @access
Scenario: Webservice access
	Given I have access to the api
	When I make a "get" request to "isalive" with payload ""
	Then I should receive a status of "OK"

@ticket @getlatest
Scenario: Get tickets given the last activity date
	Given I have access to the api
	When I make a "get" request to return a list from "tickets" with a date set to last hour
	Then I should receive a status of "OK"
        And I should receive a "Ticket" object array
		And the object array returned should have a property of "Id"
		And the object array returned should have a property of "TicketTypeId"
		And the object array returned should have a property of "AccountId"
		And the object array returned should have a property of "LastActivityDateTime"
		And the object array returned should have a property of "StatusId"
		And the object array returned should have a property of "CreateDateTime"
		And the object array returned should have a property of "Title"
		And the object array returned should have a property of "Description"
		And the object array returned should have a property of "PriorityId"
		And the object array returned should have a property of "DueDateTime"
		And the object array returned should have a property of "CompleteDateTime"

@ticket @get @bad
Scenario Outline: Retrieve tickets with incorrect dates
	Given I have access to the api
	When I make a "get" request to "tickets?date={badDate}" with payload ""
	Then I should receive a status of "OK"
Examples:
	| badDate 				|
	| 2020-03-44T11:22:37	|
	| 2020-13-24T11:22:37	|
	| 2020-03-24T25:22:37	|
	| 2020-03-24T11:62:37	|
	| 2020-03-24T11:22:67	|
