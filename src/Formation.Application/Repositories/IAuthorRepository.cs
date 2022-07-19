using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Repositories
{
    public interface IAuthorRepository
    {
        public Task<int> Add(AuthorDTO dto);

        public Task<AuthorDTO> GetOneAuthorById(int id);
    }
}
