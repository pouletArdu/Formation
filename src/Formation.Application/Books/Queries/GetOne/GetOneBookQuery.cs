namespace Formation.Application.Books.Queries.GetOne;

public class GetOneBookQuery : IRequest<BookDTO>
{
    public int Id { get; set; }
}

public class GetOneBookQueryHandler : IRequestHandler<GetOneBookQuery, BookDTO>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetOneBookQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookDTO> Handle(GetOneBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetOneBookById(request.Id);

        var bookDto = _mapper.Map<BookDTO>(book);
        return bookDto;
    }
}