using Application.Validation.Tests.Drivers;
using Formation.Application.Books.Commands.Create;
using System;
using TechTalk.SpecFlow;

namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class BookStepDefinitions
    {
        private CreateBookCommand _createBookCommand;
        private int _bookResultId;
        private BookDTO _bookResult;
        private BookDTO _bookExpected;
        private Exception _exception;

        [AfterTestRun]
        public static void ClearSession()
        {
            BookRepositoryMock.Dispose();
        }

        [Given(@"I have an book to add")]
        public void GivenIHaveAnBookToAdd()
        {
            _createBookCommand = new CreateBookCommand();
        }

        [Given(@"his title is ""([^""]*)""")]
        public void GivenHisTitleIs(string title)
        {
            _createBookCommand.Title = title;
        }

        [Given(@"his description is ""([^""]*)""")]
        public void GivenHisDescriptionIs(string description)
        {
            _createBookCommand.Description = description;
        }

        [Given(@"there is an author with id (.*)")]
        public void GivenThereIsAnAuthorWithId(int authorId)
        {
            AuthorRepositoryMock.AddAuthors(new List<AuthorDTO> { new AuthorDTO { Id = authorId } });
        }


        [Given(@"his author id is (.*)")]
        public void GivenHisAuthorIdIs(int authorId)
        {
            _createBookCommand.AuthorId = authorId;
        }


        [Given(@"his publication date is ""([^""]*)""")]
        public void GivenHisPublicationDateIs(string publicationDate)
        {
            _createBookCommand.PublicationDate = DateTime.Parse(publicationDate);
        }

        [Given(@"his number of page is ""([^""]*)""")]
        public void GivenHisNumberOfPageIs(string numberOfPage)
        {
            _createBookCommand.NumberOfPage = int.Parse(numberOfPage);
        }

        [When(@"I ask to add the book")]
        public async Task WhenIAskToAddTheBook()
        {
            try
            {
                _bookResultId = await Testing.SendAsync(_createBookCommand);
                _bookResultId.Should().BeGreaterThan(0);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the book is added")]
        public void ThenTheBookIsAdded()
        {
            BookRepositoryMock.Books.Should().NotBeNull();
            BookRepositoryMock.Books.Should().OnlyHaveUniqueItems();
            var book = BookRepositoryMock.Books.First();
            book.Title.Should().Be(_createBookCommand.Title);
            book.Description.Should().Be(_createBookCommand.Description);
            book.PublicationDate.Should().Be(_createBookCommand.PublicationDate);
        }
    }
}
