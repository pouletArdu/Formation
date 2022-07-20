Feature: Book

A short summary of the feature

@AddBook
Scenario: I want to add a book
	Given I have a book to add
	And his title is "Toto"
	And his numerofpage is 15
	When I ask to add the book
	Then The book is added

@AddBook
Scenario: I want to add a book without title
	Given I have a book to add
	And his numerofpage is 15
	When I ask to add the book
	Then a ValidationException is raised in book
