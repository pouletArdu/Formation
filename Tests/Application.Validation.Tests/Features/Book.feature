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


Scenario: I Want to get Book by his ID
Given there are books :
	| Id | Title | Description | PublicationDate | NumberOfPage | AuthorId |
	| 1  | Titi  | Titi        | 1986/01/01      | 10           | 1 |
	| 2  | Toto  | Toto        | 1986/02/01      | 9            | 1 |
	| 3  | Tata  | Tata        | 1986/03/01      | 8            | 1 |
	| 4  | Tutu  | Tutu        | 1986/04/01      | 7            | 1 |
	| 5  | Tete  | Tete        | 1986/05/01      | 6            | 1 |
	| 6  | Tyty  | Tyty        | 1986/06/01      | 5            | 1 |
When I ask to get the book with id 5
Then I get the expected book