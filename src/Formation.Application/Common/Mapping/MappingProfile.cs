using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formation.Application.Authors.Commands.Create;
using Formation.Application.Books.Commands.Create;

namespace Formation.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAuthorCommand, AuthorDTO>();

            CreateMap<CreateBookCommand, BookDTO>();
        }
    }
}
