﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Authors.Queries.GetOne
{
    public class GetOneAuthorQuery : IRequest<AuthorDTO>
    {
        public int Id { get; set; }

        public GetOneAuthorQuery(int id   )
        {
            Id = id;
        }
    } 

    public class GetQueryHandler : IRequestHandler<GetOneAuthorQuery, AuthorDTO>
    {
        private readonly AuthorRepository _repository;
        //private readonly IMapper _mapper;
        public GetQueryHandler(AuthorRepository repository) //IMapper mapper
        {
            _repository = repository;
            //_mapper = mapper;
        }

        public async Task<AuthorDTO> Handle(GetOneAuthorQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            //var dto = _mapper.Map<AuthorDTO>(request.Id);
            var dto = await _repository.Get(request.Id);

            return dto;
        }
    }
}
