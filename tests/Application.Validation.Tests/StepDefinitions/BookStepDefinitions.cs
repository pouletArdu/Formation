using Application.Validation.Tests.Drivers;
using Formation.Application.Books.Commands.Create;
using Formation.Domain.Entities;

namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class BookStepDefinitions
    {
        private CreateBookCommand _createBookCommand = null!;
        private int _bookResultId;
        private readonly BookDTO _bookResult;
        private readonly BookDTO _bookExpected;
        private Exception _exception;

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
        public void GivenHisTitleIs(string myBook)
        {
            _createBookCommand.Title = myBook;
        }

        [Given(@"his description is ""([^""]*)""")]
        public void GivenHisDescriptionIs(string description)
        {
            _createBookCommand.Description = description;
        }

        [Given(@"there is an author with Id (.*)")]
        public void GivenThereIsAnAuthorWithId(int id)
        {
            AuthorRepositoryMock.AddAuthors(new List<AuthorDTO> { new AuthorDTO { Id = id } });
        }

        [Given(@"his author id is (.*)")]
        public void GivenHisAuthorIdIs(int id)
        {
            _createBookCommand.AuthorId = id;
        }


        [Given(@"his publicationDate is ""([^""]*)""")]
        public void GivenHisPublicationDateIs(string publicationDate)
        {
            _createBookCommand.PublicationDate = DateTime.Parse(publicationDate);
        }

        [Given(@"his number of pages is (.*)")]
        public void GivenHisNumberOfPagesIs(int numberOfPages)
        {
            _createBookCommand.NumberOfPages = numberOfPages;
        }

        [When(@"I ask to add the book")]
        public async Task WhenIAskToAddTheBook()
        {
            try
            {
                _bookResultId = await Testing.SendAsync(_createBookCommand);
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Then(@"The book is added")]
        public void ThenTheBookIsAdded()
        {
            _bookResultId.Should().Be(1);
            BookRepositoryMock.Books.Should().NotBeNull();
            BookRepositoryMock.Books.Should().OnlyHaveUniqueItems();
            var author = BookRepositoryMock.Books.First();
            author.Title.Should().Be(_createBookCommand.Title);
            author.Description.Should().Be(_createBookCommand.Description);
            author.PublicationDate.Should().Be(_createBookCommand.PublicationDate);
        }
    }
}
