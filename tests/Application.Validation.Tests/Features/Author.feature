Feature: Author

Manage authors

@AddAuthor
Scenario: I want to add an author
	Given I have an author to add
	And his lastName is "Doe"
	And his firstName is "John"
	And his gender is "Male"
	And his birthday is "1998/03/01"
	When I ask to add the author
	Then The author is added

@AddAuthor
Scenario: I want to add an author without firstName
	Given I have an author to add
	And his lastName is "Doe"
	And his gender is "Male"
	And his birthday is "1985/03/01"
	When I ask to add the author
	Then A ValidatationException is raised

@GetAuthor
Scenario: I want to get an author by his Id
   Given there are authors :
       | Id | FirstName | LastName | BirthDay   | Gender |
       |  1 |   99      |    99    | 1983/04/01 |   Male |
	   |  2 |   99      |    99    | 1983/04/01 |   Male |
	   |  3 |   99      |    99    | 1983/04/01 |   Male |
	   |  4 |   99      |    99    | 1983/04/01 |   Male |
	   |  5 |   John    |    Doe   | 1983/04/01 |   Male |
	   |  6 |   99      |    99    | 1983/04/01 |   Male |
   When I ask to get the author with id 5
   Then I get the expected author



