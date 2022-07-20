namespace Formation.Application.Books.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly BookRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(BookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<BookDTO>(command);

            return await _repository.Add(dto);
        }
    }
}
