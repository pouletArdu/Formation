namespace Formation.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorDTO, Author>()
            .ReverseMap();

        CreateMap<BookDTO, Book>()
            .ReverseMap()
            .IncludeAllDerived()
            .ForMember(dest => dest.AuthorId, act => act.MapFrom(org => org.Author.Id))
            .ForMember(dest => dest.Author, act => act.MapFrom(org => new AuthorDTO
            {
                FirstName = org.Author.FirstName,
                LastName = org.Author.LastName,
            }));
    }
}
