using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure.Repositories
{
    public class AuthorRepositoryImp : AuthorRepository
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
    }
}
