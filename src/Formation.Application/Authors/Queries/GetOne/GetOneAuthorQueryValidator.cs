using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Authors.Queries.GetOne
{
    public class GetOneAuthorQueryValidator : AbstractValidator<GetOneAuthorQuery>
    {
        public GetOneAuthorQueryValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(0);
        }
    }
}
