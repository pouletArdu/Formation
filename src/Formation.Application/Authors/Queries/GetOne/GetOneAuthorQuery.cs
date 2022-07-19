using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Authors.Queries.GetOne
{
    public class GetOneAuthorQuery : IRequest<AuthorDTO>
    {
        public int Id { get; set; }

        public GetOneAuthorQuery(int id   )
        {
            Id = id;
        }
    }
}
