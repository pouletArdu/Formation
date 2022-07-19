using System;
using TechTalk.SpecFlow;
using Formation.Domain.Entities;
using Formation.Domain.Enums;
using Formation.Application.Authors.Commands.Create;
using Application.Validation.Tests.Drivers;
using Formation.Application.Common.Exceptions;
using Formation.Application.Authors.Queries.GetOne;

namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class AuthorStepDefinitions
    {
        private CreateAuthorCommand _createAuthorCommand = null!;
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

        [Given(@"his lastName is ""([^""]*)""")]
        public void GivenHisLastNameIs(string lastName)
        {
            _createAuthorCommand.LastName = lastName;
        }

        [Given(@"his firstName is ""([^""]*)""")]
        public void GivenHisFirstNameIs(string firstName)
        {
            _createAuthorCommand.FirstName = firstName;
        }

        [Given(@"his gender is ""([^""]*)""")]
        public void GivenHisGenderIs(string male)
        {
            if (Enum.TryParse<Gender>(male, out var gender))
            {
                _createAuthorCommand.Gender = gender;
            }
        }

        [Given(@"his birthday is ""([^""]*)""")]
        public void GivenHisBirthdayIs(string birthDay)
        {
            _createAuthorCommand.BirthDay = DateTime.Parse(birthDay);
        }

        [When(@"I ask to add the author")]
        public async Task WhenIAskToAddTheAuthor()
        {
            //var result = await Testing.SendAsync(_createAuthorCommand);
            //result.Should().Be(1);
            try
            {
                _authorResultId = await Testing.SendAsync(_createAuthorCommand);
            }
            catch(Exception e)
            {
                _exception = e;
            }
        }

        [Then(@"The author is added")]
        public void ThenTheAuthorIsAdded()
        {
            _authorResultId.Should().Be(1);
            AuthorRepositoryMock.Authors.Should().NotBeNull();
            AuthorRepositoryMock.Authors.Should().OnlyHaveUniqueItems();
            var author = AuthorRepositoryMock.Authors.First();
            author.LastName.Should().Be(_createAuthorCommand.LastName);
            author.FirstName.Should().Be(_createAuthorCommand.FirstName);
            author.BirthDay.Should().Be(_createAuthorCommand.BirthDay);
        }

        [Then(@"A ValidatationException is raised")]
        public async void ThenAValidatationExceptionIsRaised()
        {
            _exception.Should().BeOfType<ValidationException>();
        }


        [Given(@"there are authors :")]
        public void GivenThereAreAuthors(Table table)
        {
            AuthorRepositoryMock.AddAuthors(table.CreateSet<AuthorDTO>());
        }

        [When(@"I ask to get the author with id (.*)")]
        public async Task WhenIAskToGetTheAuthorWithId(int id)
        {
            _authorExpected = AuthorRepositoryMock.Authors.FirstOrDefault(a => a.Id == id); //.Should().NotBeNull();

            _authorExpected.Should().NotBeNull();

            _authorResult = await Testing.SendAsync(new GetOneAuthorQuery(id));
        }

        [Then(@"I get the expected author")]
        public void ThenIGetTheExpectedAuthor()
        {
            _authorResult.Should().NotBeNull();
            _authorResult.LastName.Should().Be(_authorExpected.LastName);
            _authorResult.FirstName.Should().Be(_authorExpected.FirstName);
            _authorResult.BirthDay.Should().Be(_authorExpected.BirthDay);
        }

    }
}
