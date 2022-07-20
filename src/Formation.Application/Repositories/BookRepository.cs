using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Repositories
{
    public interface BookRepository
    {
        Task<int> Add(BookDTO dto);
    }
}
