using System;

using Formation.Domain.Entities;
using Formation.Application.Authors.Commands.Create;
using Application.Validation.Tests.Drivers;
using Formation.Application.Authors.Queries.GetOne;

namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class AuthorStepDefinitions
    {
        private CreateAuthorCommand _createAuthorCommand;
        private int _authorResultId;
        private AuthorDTO _authorResult;
        private AuthorDTO _authorExpected;
        private Exception _exception;

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
            if (Enum.TryParse<Gender>(gender, out var genderEnum))
            {
                _createAuthorCommand.Gender = genderEnum;
            }
        }

        [Given(@"his birthday is ""([^""]*)""")]
        public void GivenHisBirthdayIs(string birthdayAuthor)
        {
            if (DateTime.TryParse(birthdayAuthor, out var birthday))
            {
                _createAuthorCommand.Birthday = birthday;
            }
        }

        [When(@"I ask to add th author")]
        public async Task WhenIAskToAddThAuthor()
        {
            try
            {
                _authorResultId = await Testing.SendAsync(_createAuthorCommand);
                _authorResultId.Should().BeGreaterThan(0);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the author is added")]
        public void ThenTheAuthorIsAdded()
        {
            AuthorRepositoryMock.Authors.Should().NotBeNull();
            AuthorRepositoryMock.Authors.Should().OnlyHaveUniqueItems();
            var author = AuthorRepositoryMock.Authors.First();
            author.FirstName.Should().Be(_createAuthorCommand.FirstName);
            author.LastName.Should().Be(_createAuthorCommand.LastName);
            author.Birthday.Should().Be(_createAuthorCommand.Birthday);
        }

        [Then(@"A ValidationException is raised")]
        public async void ThenAValidationExceptionIsRaised()
        {
            _exception.Should().BeOfType<ValidationException>();
        }

        [Given(@"there are authors :")]
        public void GivenThereAreAuthors(Table table)
        {
            AuthorRepositoryMock.AddAuthors(table.CreateSet<AuthorDTO>());
        }

        [When(@"I ask to get the author whith id (.*)")]
        public async Task WhenIAskToGetTheAuthorWhithId(int idAuthor)
        {
            _authorExpected = AuthorRepositoryMock.Authors.FirstOrDefault(a => a.Id == idAuthor);
            _authorExpected.Should().NotBeNull();
            _authorResult = await Testing.SendAsync(new GetOneAuthorQuery(idAuthor));
            _authorResult.Id.Should().Be(idAuthor);
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
