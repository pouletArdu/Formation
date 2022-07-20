namespace Formation.Application.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public AuthorDTO Author { get; set; }

        public int AuthorId { get; set; }

        public DateTime PublicationDate { get; set; }

        public int NumberOfPage { get; set; }
    }

    public class CreateCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator();
            validator.Validate(request);

            var dto = _mapper.Map<BookDTO>(request);
            return await _repository.Add(dto);
        }
    }
}
