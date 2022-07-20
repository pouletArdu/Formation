Feature: Book

A short summary of the feature

@AddBook
Scenario: I want to add an book
	Given I have an book to add
	And his title is "John"
	And his description is "Doe"
	And his author id is "1"
	And his publication date is "1983/02/22"
	And his number of page is "50"
	When I ask to add the book
	Then the book is added