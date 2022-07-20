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
            var author = await _context.Authors.FindAsync(dto.Author.Id);
            var entity = _mapper.Map<Book>(dto);
            entity.Author = author;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<BookDTO> Get(int id)
        {
            var book = _context.Books.Include(a => a.Author).Where(b => b.Id == id).FirstOrDefaultAsync().Result;
            var bookDTO = _mapper.Map<BookDTO>(book);

            return bookDTO;
        }
    }
}
