Feature: Author

Manage authors

@AddAuthor
Scenario: I want to add an author
	Given I have an author to add
	And his lastname is "Toto"
	And his firstname is "Tutu"
	And his gender is "Male"
	And his birthday is "1986/03/25"
	When I ask to add the author
	Then The author is added

@AddAuthor
Scenario: I want to add an author without firstname
	Given I have an author to add
	And his lastname is "Toto"
	And his gender is "Male"
	And his birthday is "1986/03/25"
	When I ask to add the author
	Then a ValidationException is raised


Scenario: I Want to get Author by his ID
Given there are authors :
	| Id | Firstname | LastName | Birthday | Gender |
	|  1  |    Titi       |    Titi     |   1986/01/01       |    Male    |
	|  2  |    Toto       |    Toto     |   1986/02/01       |    Male    |
	|  3  |    Tata       |    Tata     |   1986/03/01       |    Male    |
	|  4  |    Tutu       |    Tutu     |   1986/04/01       |    Male    |
	|  5  |    Tete       |    Tete     |   1986/05/01       |    Male    |
	|  6  |    Tyty       |    Tyty     |   1986/06/01       |    Male    |
When I ask to get the author with id 5
Then I get the expected author