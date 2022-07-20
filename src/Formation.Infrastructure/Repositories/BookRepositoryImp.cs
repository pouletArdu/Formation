namespace Formation.Infrastructure.Repositories;

public class BookRepositoryImp : IBookRepository
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
        entity.Author = _context.Authors.FirstOrDefault(a => a.Id == dto.AuthorId);

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<BookDTO> GetOneBookById(int id)
    {
        var book = await _context
                .Books
                .Include(x => x.Author)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        var dto = _mapper.Map<BookDTO>(book);
        return dto;
    }

    public async Task<IEnumerable<BookDTO>> GetAllBook()
    {
        var entity = await _context.Books.ToListAsync();

        var dto = new List<BookDTO>();

        foreach (var author in entity)
        {
            dto.Add(_mapper.Map<BookDTO>(author));
        }

        return dto;
    }
}