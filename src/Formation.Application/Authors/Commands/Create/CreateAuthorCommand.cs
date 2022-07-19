namespace Formation.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }
    }

    public class CreateCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuthorCommandValidator();
            validator.Validate(request);

            var dto = _mapper.Map<AuthorDTO>(request);
            return await _repository.Add(dto);
        }
    }
}
