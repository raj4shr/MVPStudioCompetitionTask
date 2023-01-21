Feature: ShareSkill

Scenario to add a new listig

Background: Login to the website
	Given User logs in to the website

Scenario: Add a new user share skill for a user
	Given A new user share skill is added with '<title>','<description>', '<category>' and '<subcategory>'
	Then The share skill is added to the user profile successfully

	Examples: 
	| title    | description  | category           | subcategory |
	| Cucumber | BDD in Java  | Programming & Tech | QA          |
	| NUnit    | Unit Testing | Programming & Tech | QA          |



