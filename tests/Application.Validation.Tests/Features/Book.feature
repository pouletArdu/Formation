Feature: Book

Manage authors

@AddBook
Scenario: I want to add a book
	Given I have a book to add
	And there is an author with Id 1
	And his title is "myBook"
	And his description is "Formation clean architecture"
	And his author id is 1
	And his publicationDate is "1998/03/01"
	And his number of pages is 300
	When I ask to add the book
	Then The book is added
