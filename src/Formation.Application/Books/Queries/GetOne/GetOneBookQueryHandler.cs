namespace Formation.Application.Books.Queries.GetOne
{
    public class GetOneBookQueryHandler : IRequestHandler<GetOneBookQuery, BookDTO>
    {
        private readonly BookRepository _repository;
        private readonly IMapper _mapper;

        public GetOneBookQueryHandler(BookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetOneBookQuery query, CancellationToken cancellationToken)
        {
            return await _repository.Get(query.Id);
        }
    }
}
