using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure.Repositories
{
    public class BookRepositoryImp : BookRepository
    {
        private readonly FormationDbContext _context;
        private readonly IMapper _mapper;

        public BookRepositoryImp(FormationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(BookDTO dto)
        {
            //var entity = new Author
            //{
            //    BirthDate = dto.BirthDate,
            //    FirstName = dto.FirstName,
            //    LastName = dto.LastName
            //    //...
            //};

            var entity = _mapper.Map<Book>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<BookDTO> Get(int id)
        {
            //throw new NotImplementedException();
            var book = await _context.Books.FindAsync(id);
            var bookDTO = _mapper.Map<BookDTO>(book);

            return bookDTO;
        }
    }
}
