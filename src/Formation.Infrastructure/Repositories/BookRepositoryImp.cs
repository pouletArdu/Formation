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
}