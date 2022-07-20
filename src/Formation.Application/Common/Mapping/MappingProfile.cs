using Formation.Application.Authors.Commands.Create;
using Formation.Application.Books.Commands.Create;

namespace Formation.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAuthorCommand, AuthorDTO>()
                .ReverseMap();

            CreateMap<CreateBookCommand, BookDTO>()
                .ReverseMap();
        }
    }
}
