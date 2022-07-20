using Application.Validation.Tests.Drivers;
using Formation.Application.Books.Commands.Create;
using Formation.Application.Common.Exceptions;

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

    }
}
