Feature: Book

A short summary of the feature

@AddBook
Scenario: I want to add an book
	Given I have an book to add
	And there is an author with id 1
	And his title is "Clean Arhictecture"
	And his description is "Formation Clean Architecture"
	And his author id is 1
	And his publication date is "1983/02/22"
	And his number of page is "50"
	When I ask to add the book
	Then the book is added