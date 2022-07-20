namespace Formation.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDTO, Book>()
                .ReverseMap()
                .IncludeAllDerived()                
                .ForMember(dest => dest.Author, act => act.MapFrom(org => new AuthorDTO
                {
                    FirstName = org.Author.FirstName,
                    LastName = org.Author.LastName
                }));
            CreateMap<AuthorDTO, Author>()
                .ReverseMap();
        }
    }
}
