using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDTO,Author>()
                .ReverseMap();

            CreateMap<BookDTO, Book>()
                .ReverseMap();
        }
    }
}
