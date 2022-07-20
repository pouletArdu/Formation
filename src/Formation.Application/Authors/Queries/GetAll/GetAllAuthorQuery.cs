namespace Formation.Application.Authors.Queries.GetAll;

public class GetAllAuthorQuery : IRequest<IEnumerable<AuthorDTO>>
{
}

public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<AuthorDTO>>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllAuthorQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDTO>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        var authorsDTO = await _repository.GetAllAuthor();

        List<AuthorDTO> result = new List<AuthorDTO>();

        foreach (var authorDTO in authorsDTO)
        {
            result.Add(_mapper.Map<AuthorDTO>(authorDTO));
        }

        return authorsDTO;
    }
}