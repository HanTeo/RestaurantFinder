Feature: RestaurantFinder Repository
	In order retrieve restaurants available nearby
	As a application that consumes JustEat API
	I want to able to call a repository method and retrive a list of restaurant

@myTag
Scenario: Get method returns a list of restaurants
	Given I have created an instance of the JustEatRepository
	Then I the base URL should be http://api-interview.just-eat.com/
	And I the request URI should be restaurants?q=
	When I call the get method with outcode SE19
	Then the result should be an IEnumerable of Restaurant
	And the result should not be empty

Scenario: Get method returns empty list of a wrong outcode is entered
	Given I have created an instance of the JustEatRepository
	When I call the get method with outcode garbage
	Then the result should be an empty enumeration

Scenario: Get method returns empty list of a no outcode is entered
	Given I have created an instance of the JustEatRepository
	When I call the get method with null arguments
	Then the result should be an empty enumeration
