Feature: Author

Manage authors

@AddAuthor
Scenario: I want to add an author
	Given I have an author to add
	And his lastname is "John"
	And his firstname is "Doe"
	And his gender is "Male"
	And his birthday is "1983/02/22"
	When I ask to add th author
	Then the author is added

@AddAuthor
Scenario: I want to add an author without Firstname
	Given I have an author to add
	And his lastname is "John"
	And his firstname is ""
	And his gender is "Male"
	And his birthday is "1983/02/22"
	When I ask to add th author
	Then A ValidationException is raised

Scenario: I Want to get Author by his ID
	Given there are authors :
	 | Id | FirstName | LastName   | BirthDay  | Gender |
	 |  1  | gg          |      gg    | 1983/04/01   |    Male    |
	 |  2  | gg          |      gg    | 1983/04/01   |    Male    |
	 |  3  | gg          |      gg    | 1983/04/01   |    Male    |
	 |  4  | gg          |      gg    | 1983/04/01   |    Male    |
	 |  5  | John        |      Doe   | 1985/04/01   |    Male    |
	 |  6  | gg          |      gg    | 1983/04/01   |    Male    |
	When  I ask to get the author whith id 5
	Then I get the expected author 
