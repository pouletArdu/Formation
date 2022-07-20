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
            var author = _context.Authors.FindAsync(dto.Author.Id).Result;
            var entity = _mapper.Map<Book>(dto);
            entity.Author = _mapper.Map<Author>(author);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<BookDTO> Get(int id)
        {
            var author = _context.Authors.FindAsync(id).Result;
            var book = _context.Books.FindAsync(id).Result;
            var bookDTO = _mapper.Map<BookDTO>(book);
            bookDTO.Author = _mapper.Map<AuthorDTO>(author);

            return bookDTO;
        }
    }
}
