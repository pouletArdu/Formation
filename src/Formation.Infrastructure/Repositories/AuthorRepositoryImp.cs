using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure.Repositories
{
    public class AuthorRepositoryImp : IAuthorRepository
    {
        private readonly FormationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepositoryImp(FormationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(AuthorDTO dto)
        {
            var entity = _mapper.Map<Author>(dto);
            

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthor()
        {
            var entity = await _context.Authors.ToListAsync();

            var dto = new List<AuthorDTO>();

            foreach (var author in entity)
            {
                dto.Add(_mapper.Map<AuthorDTO>(author));
            }

            return dto;
        }

        public async Task<AuthorDTO> GetOneAuthorById(int id)
        {
            var entity = await _context
                .Authors
                .Include(x => x.Books)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();


            var dto = _mapper.Map<AuthorDTO>(entity);
            return dto;
        }
    }
}
