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
            var entity = _mapper.Map<Book>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<BookDTO> Get(int id)
        {
            var book = await _context.Authors.FindAsync(id);
            var bookDTO = _mapper.Map<BookDTO>(book);

            return bookDTO;
        }
    }
}
