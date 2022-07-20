namespace Formation.Application.Authors.Queries.GetOne
{
    public class GetOneAuthorQueryHandler : IRequestHandler<GetOneAuthorQuery,AuthorDTO>
    {
        private readonly AuthorRepository _repository;
        private readonly IMapper _mapper;

        public GetOneAuthorQueryHandler(AuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Handle(GetOneAuthorQuery query, CancellationToken cancellationToken)
        {
            return await _repository.Get(query.Id);
        }

    }
}
