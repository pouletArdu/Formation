using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; } = null;
        public string Description { get; set; } = null;
        public int AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfPages { get; set; }
    }

    public class CreateCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly BookRepository _repository;
        private readonly IMapper _mapper;

        public CreateCommandHandler(BookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            //var validator = new CreateAuthorCommandValidator();

            var dto = _mapper.Map<BookDTO>(command);
            return await _repository.Add(dto);
        }
    }
}
