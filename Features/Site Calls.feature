Feature: Sites Service
	In order to return site records from the Autotask API
	As an API developer
	I want to understand the sites service

@site @access
Scenario: Webservice access
	Given I have access to the api
	When I make a "get" request to "isalive" with payload ""
	Then I should receive a status of "OK"

@site @getlatest
Scenario: Get sites given the last activity date
	Given I have access to the api
	When I make a "get" request to return a list from "sites" with a date set to last month
	Then I should receive a status of "OK"
        And I should receive a "Site" object array
		And the object array returned should have a property of "Id"
		And the object array returned should have a property of "ParentAccountId"
		And the object array returned should have a property of "AccountName"
		And the object array returned should have a property of "Address1"
		And the object array returned should have a property of "Address2"
		And the object array returned should have a property of "City"
		And the object array returned should have a property of "State"
		And the object array returned should have a property of "Zipcode"
		And the object array returned should have a property of "Country"
		And the object array returned should have a property of "DateCreated"
		And the object array returned should have a property of "ExternalIdentifier"

@site @get @bad
Scenario Outline: Retrieve sites with incorrect dates
	Given I have access to the api
	When I make a "get" request to "sites?date={badDate}" with payload ""
	Then I should receive a status of "OK"
Examples:
	| badDate 				|
	| 2020-03-44T11:22:37	|
	| 2020-13-24T11:22:37	|
	| 2020-03-24T25:22:37	|
	| 2020-03-24T11:62:37	|
	| 2020-03-24T11:22:67	|
