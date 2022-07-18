namespace Formation.Application.Authors.Commands.Create
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand,int>
    {
        private readonly AuthorRepository _repository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(AuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<AuthorDTO>(command);

            return await _repository.Add(dto);
        }
    }
}
