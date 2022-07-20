using Application.Validation.Tests.Drivers;
using Formation.Application.Books.Commands.Create;
using Formation.Application.Books.Queries.GetOne;
using Formation.Application.Common.Exceptions;
using TechTalk.SpecFlow.Assist;

namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class BookStepDefinitions
    {
        private CreateBookCommand _createBookCommand = null!;
        private int _bookResultId;
        private BookDTO _bookResult;
        private BookDTO _bookExpected;
        private Exception? _bookException;

        [AfterTestRun]
        public static void ClearSession()
        {
            BookRepositoryMock.Dispose();
        }

        [Given(@"I have a book to add")]
        public void GivenIHaveABookToAdd()
        {
            _createBookCommand = new CreateBookCommand();
        }

        [Given(@"his title is ""([^""]*)""")]
        public void GivenHisTitleIs(string title)
        {
            _createBookCommand.Title = title;
        }

        [Given(@"his numerofpage is (.*)")]
        public void GivenHisNumerofpageIs(int numberOfPage)
        {
            _createBookCommand.NumberOfPage = numberOfPage;
        }

        [Given(@"his author id is (.*)")]
        public void GivenHisAuthorIdIs(int authorId)
        {
            _createBookCommand.AuthorId = authorId;
        }


        [When(@"I ask to add the book")]
        public async Task WhenIAskToAddTheBookAsync()
        {
            try
            {
                _bookResultId = await Testing.SendAsync(_createBookCommand);
                _bookResultId.Should().Be(1);
            }
            catch (Exception e)
            {
                _bookException = e;
            }
        }

        [Then(@"The book is added")]
        public void ThenTheBookIsAdded()
        {
            BookRepositoryMock.Books.Should().NotBeNull();
            BookRepositoryMock.Books.Should().OnlyHaveUniqueItems();
            var firstBook = BookRepositoryMock.Books.First();
            firstBook.Title.Should().Be(_createBookCommand.Title);
            firstBook.NumberOfPage.Should().Be(_createBookCommand.NumberOfPage);
        }

        [Then(@"a ValidationException is raised in book")]
        public void ThenAValidationExceptionIsRaisedInBook()
        {
            _bookException.Should().BeOfType<ValidationException>();
        }

        [Given(@"there is an author with Id (.*)")]
        public void GivenThereIsAnAuthorWithId(int id)
        {
            AuthorRepositoryMock.AddAuthors(new List<AuthorDTO> { new AuthorDTO { Id = id } });
        }

        [Given(@"there are books :")]
        public void GivenThereAreBooks(Table table)
        {
            BookRepositoryMock.AddBooks(table.CreateSet<BookDTO>());
        }

        [When(@"I ask to get the book with id (.*)")]
        public async Task WhenIAskToGetTheBookWithIdAsync(int bookID)
        {
            _bookExpected = BookRepositoryMock.Books.FirstOrDefault(a => a.Id == bookID);
            _bookExpected.Should().NotBeNull();
            _bookResult = await Testing.SendAsync(new GetOneBookQuery(bookID));
        }

        [Then(@"I get the expected book")]
        public void ThenIGetTheExpectedBook()
        {
            _bookResult.Should().NotBeNull();
            _bookResult.Title.Should().Be(_bookExpected.Title);
            _bookResult.Author.Should().Be(_bookExpected.Author);
        }

    }
}
