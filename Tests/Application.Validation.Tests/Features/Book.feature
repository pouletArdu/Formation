Feature: Book

A short summary of the feature

@AddBook
Scenario: I want to add a book
	Given I have a book to add
	And there is an author with Id 1
	And his title is "Toto"
	And his numerofpage is 15
	And his author id is 1
	When I ask to add the book
	Then The book is added

@AddBook
Scenario: I want to add a book without title
	Given I have a book to add
	And there is an author with Id 1
	And his numerofpage is 15
	And his author id is 1
	When I ask to add the book
	Then a ValidationException is raised in book
