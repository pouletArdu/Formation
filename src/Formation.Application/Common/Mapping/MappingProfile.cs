using Formation.Application.Authors.Commands.Create;

namespace Formation.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAuthorCommand, AuthorDTO>()
                .ReverseMap();
        }
    }
}
