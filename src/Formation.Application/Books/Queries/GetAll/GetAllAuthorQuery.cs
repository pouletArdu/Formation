namespace Formation.Application.Books.Queries.GetAll;

public class GetAllBookQuery : IRequest<IEnumerable<BookDTO>>
{
}

public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, IEnumerable<BookDTO>>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetAllBookQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDTO>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        var booksDTO = await _repository.GetAllBook();

        List<BookDTO> result = new List<BookDTO>();

        foreach (var bookDTO in booksDTO)
        {
            result.Add(_mapper.Map<BookDTO>(bookDTO));
        }

        return booksDTO;
    }
}