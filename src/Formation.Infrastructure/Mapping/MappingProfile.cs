namespace Formation.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}
