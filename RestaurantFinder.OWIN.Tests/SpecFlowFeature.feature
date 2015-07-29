Feature: SpecFlowFeature
	In order to find something to eat
	As a hungry spender
	I want to be able to find some good restaurants by just the outcode

@mytag
Scenario: Find restaurants by outcode
	Given I have entered http://localhost:8080/restaurants into the webpage
	And I have entered SE17 into the input box
	When I press search
	Then I should see a table of restaurants listed on the screen
