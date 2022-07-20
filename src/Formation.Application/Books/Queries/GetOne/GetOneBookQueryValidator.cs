using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Books.Queries.GetOne
{
    internal class GetOneBookQueryValidator : AbstractValidator<GetOneBookQuery>
    {
        public GetOneBookQueryValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(0);
        }
    }
}
