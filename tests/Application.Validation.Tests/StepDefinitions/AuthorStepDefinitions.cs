global using Application.Validation.Tests.Drivers;
using Formation.Application.Authors.Commands.Create;
using Formation.Application.Authors.Queries.GetOne;
using Formation.Application.Common.Exceptions;


namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class AuthorStepDefinitions
    {
        private CreateAuthorCommand _createAuthorCommand = null!;
        private int _authorResultId;
        private AuthorDTO _authorResult;
        private AuthorDTO _authorExpected;
        private Exception? _exception;

        [AfterTestRun]
        public static void ClearSession()
        {
            AuthorRepositoryMock.Dispose();
        }

        [Given(@"I have an author to add")]
        public void GivenIHaveAnAuthorToAdd()
        {
            _createAuthorCommand = new();
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
        public void GivenHisBirthdayIs(string date)
        {
            _createAuthorCommand.BirthDay = DateTime.Parse(date);
        }

        [When(@"I ask to add the author")]
        public async Task WhenIAskToAddTheAuthor()
        {
            try
            {
                _authorResultId = await Testing.SendAsync(_createAuthorCommand);
            }
            catch (Exception ex)
            {

                _exception = ex;
            }
        }

        [Then(@"The author is added")]
        public void ThenTheAuthorIsAdded()
        {
            _authorResultId.Should().Be(1);
            AuthorRepositoryMock.Authors.Should().NotBeNull();
            AuthorRepositoryMock.Authors.Should().OnlyHaveUniqueItems();
            var author = AuthorRepositoryMock.Authors.First();
            author.BirthDay.Should().Be(_createAuthorCommand.BirthDay);
            author.FirstName.Should().Be(_createAuthorCommand.FirstName);
            author.LastName.Should().Be(_createAuthorCommand.LastName);
        }

        [Then(@"A ValidationException is raised")]
        public void ThenAValidationExceptionIsRaised()
        {
            _exception.Should().BeOfType<ValidationException>();
        }

        [Given(@"there are authors :")]
        public void GivenThereAreAuthors(Table table)
        {
            AuthorRepositoryMock.AddAuthors(table.CreateSet<AuthorDTO>());
        }

        [When(@"I ask to get the author whith id (.*)")]
        public async Task WhenIAskToGetTheAuthorWhithId(int id)
        {
            _authorExpected = AuthorRepositoryMock.Authors.FirstOrDefault(a => a.Id == id);

            _authorExpected.Should().NotBeNull();

            _authorResult = await Testing.SendAsync(new GetOneAuthorQuery(id));
        }

        [Then(@"I get the expected author")]
        public void ThenIGetTheExpectedAuthor()
        {
            _authorResult.Should().NotBeNull();
            _authorResult.BirthDay.Should().Be(_authorExpected.BirthDay);
            _authorResult.FirstName.Should().Be(_authorExpected.FirstName);
            _authorResult.LastName.Should().Be(_authorExpected.LastName);
        }
    }
}
