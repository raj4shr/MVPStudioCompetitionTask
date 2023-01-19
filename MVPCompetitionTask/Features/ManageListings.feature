Feature: ManageListings

Two scenarios from Manage Listings. 1. View a listing 2. Delete a listing

Background: Login to the website
	Given User logs in to the website

Scenario Outline: Delete a share skill 
	Given A user deletes a share skill with '<title>'
	Then The share skill should be deleted successfully

	Examples: 
	| title |
	| NUnit |
 
Scenario Outline: View a share skill
	Given A user wnats to view a share skill with '<title>'
	Then The user is navigated to the share skill successfully

	Examples: 
	| title    |
	| SpecFlow |
