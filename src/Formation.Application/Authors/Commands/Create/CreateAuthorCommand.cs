using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formation.Domain.Enums;
using MediatR;

namespace Formation.Application.Authors.Commands.Create;

public class CreateAuthorCommand : IRequest<int>
{
    public string LastName { get; set; } = null;
    public string FirstName { get; set; } = null;
    public DateTime BirthDay { get; set; }
    public Gender Gender { get; set; }    
}

public class CreateCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly AuthorRepository _repository;
    private readonly IMapper _mapper;

    public CreateCommandHandler(AuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        //var validator = new CreateAuthorCommandValidator();
       
        var dto = _mapper.Map<AuthorDTO>(command);
        return await _repository.Add(dto);
    }
}
