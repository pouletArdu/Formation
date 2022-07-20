
using Application.Validation.Tests.Drivers;
using Formation.Application.Authors.Commands.Create;
using Formation.Application.Authors.Queries.GetOne;
using Formation.Application.Common.Exceptions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class AuthorStepDefinitions
    {
        private CreateAuthorCommand _createAuthorCommand = null!;
        private int _authorResultId;
        private AuthorDTO _authorResult;
        private AuthorDTO _authorExpected;
        private Exception? _AuthorException;

        [AfterTestRun]
        public static void ClearSession()
        {
            AuthorRepositoryMock.Dispose();
        }


        [Given(@"I have an author to add")]
        public void GivenIHaveAnAuthorToAdd()
        {
            _createAuthorCommand = new CreateAuthorCommand();
        }

        [Given(@"his lastname is ""([^""]*)""")]
        public void GivenHisLastnameIs(string lastname)
        {
            _createAuthorCommand.LastName = lastname;
        }

        [Given(@"his firstname is ""([^""]*)""")]
        public void GivenHisFirstnameIs(string firstname)
        {
            _createAuthorCommand.FirstName = firstname;
        }

        [Given(@"his gender is ""([^""]*)""")]
        public void GivenHisGenderIs(string gender)
        {
           if (Enum.TryParse<Gender>(gender, out var gende))
            {
                _createAuthorCommand.Gender = gende;
            }
        }

        [Given(@"his birthday is ""([^""]*)""")]
        public void GivenHisBirthdayIs(string birthday)
        {
            _createAuthorCommand.Birthday = DateTime.Parse(birthday);
        }

        [When(@"I ask to add the author")]
        public async Task WhenIAskToAddTheAuthorAsync()
        {
            try
            {
                _authorResultId = await Testing.SendAsync(_createAuthorCommand);
                _authorResultId.Should().Be(1);
            }
            catch(Exception e)
            {
                _AuthorException = e;
            }

        }

        [Then(@"The author is added")]
        public void ThenTheAuthorIsAdded()
        {
            AuthorRepositoryMock.Authors.Should().NotBeNull();
            AuthorRepositoryMock.Authors.Should().OnlyHaveUniqueItems();
            var firstAuthor = AuthorRepositoryMock.Authors.First();
            firstAuthor.Birthday.Should().Be(_createAuthorCommand.Birthday);
            firstAuthor.FirstName.Should().Be(_createAuthorCommand.FirstName);
            firstAuthor.LastName.Should().Be(_createAuthorCommand.LastName);
            firstAuthor.Gender.Should().Be(_createAuthorCommand.Gender);
        }

        [Then(@"a ValidationException is raised")]
        public void ThenAValidationExceptionIsRaised()
        {
            _AuthorException.Should().BeOfType<ValidationException>();
        }

        [Given(@"there are authors :")]
        public void GivenThereAreAuthors(Table table)
        {
            AuthorRepositoryMock.AddAuthors(table.CreateSet<AuthorDTO>());
        }

        [When(@"I ask to get the author with id (.*)")]
        public async Task WhenIAskToGetTheAuthorWithId(int authorID)
        {
            _authorExpected = AuthorRepositoryMock.Authors.FirstOrDefault(a => a.Id == authorID);
            _authorExpected.Should().NotBeNull();
            _authorResult = await Testing.SendAsync(new GetOneAuthorQuery(authorID));
        }

        [Then(@"I get the expected author")]
        public void ThenIGetTheExpectedAuthor()
        {
            _authorResult.Should().NotBeNull();
            _authorResult.Birthday.Should().Be(_authorExpected.Birthday);  
            _authorResult.FirstName.Should().Be(_authorExpected.FirstName);  
            _authorResult.LastName.Should().Be(_authorExpected.LastName);  
        }

    }
}
