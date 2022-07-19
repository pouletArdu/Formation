Feature: Author

Manage authors

@AddAuthor
Scenario: I want to add an author
	Given I have an author to add
	And his lastName is "Doe"
	And his firstName is "John"
	And his gender is "Male"
	And his birthday is "1985/03/01"
	When I ask to add the author
	Then The author is added

@AddAuthor
Scenario: I want to add an author whithout firtName
	Given I have an author to add
	And his lastName is "Doe"
	And his gender is "Male"
	And his birthday is "1985/03/01"
	When I ask to add the author
	Then A ValidationException is raised

Scenario: I Want to get Author by his ID
	Given there are authors :
		| Id | FirstName	| LastName   | BirthDay		| Gender |
		|  1  | gg          |      gg    | 1983/04/01   |    Male    |
		|  2  | gg          |      gg    | 1983/04/01   |    Male    |
		|  3  | gg          |      gg    | 1983/04/01   |    Male    |
		|  4  | gg          |      gg    | 1983/04/01   |   Male     |
		|  5  | John        |      Doe   | 1985/04/01   |    Male    |
		|  6  | gg          |      gg    | 1983/04/01   |    Male    |
	When  I ask to get the author whith id 5
	Then I get the expected author	
