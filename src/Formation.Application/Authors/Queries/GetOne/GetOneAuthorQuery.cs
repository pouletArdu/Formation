namespace Formation.Application.Authors.Queries.GetOne;

public class GetOneAuthorQuery : IRequest<AuthorDTO>
{
    public int Id { get; set; }
}

public class GetOneAuthorQueryHandler : IRequestHandler<GetOneAuthorQuery, AuthorDTO>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetOneAuthorQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AuthorDTO> Handle(GetOneAuthorQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetOneAuthorQueryValidator();
        validator.Validate(request);

        var author = await _repository.GetOneAuthorById(request.Id);

        var authorDto = _mapper.Map<AuthorDTO>(author);
        return authorDto;
    }
}