using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Books.Queries.GetOne
{
    public class GetOneBookQuery : IRequest<BookDTO>
    {
        public int Id { get; set; }

        public GetOneBookQuery(int id)
        {
            Id = id;
        }
    }

    public class GetQueryHandler : IRequestHandler<GetOneBookQuery, BookDTO>
    {
        private readonly BookRepository _repository;
        //private readonly IMapper _mapper;
        public GetQueryHandler(BookRepository repository) //IMapper mapper
        {
            _repository = repository;
            //_mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetOneBookQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            //var dto = _mapper.Map<AuthorDTO>(request.Id);
            var dto = await _repository.Get(request.Id);

            return dto;
        }
    }
}
