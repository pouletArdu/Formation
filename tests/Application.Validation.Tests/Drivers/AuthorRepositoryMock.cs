using Formation.Application.Repositories;
using Formation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation.Tests.Drivers
{
    public class AuthorRepositoryMock : AuthorRepository
    {
        public static List<AuthorDTO> Authors = new List<AuthorDTO>();
        public async Task<int> Add(AuthorDTO dto)
        {
            await Task.Yield();
            Authors.Add(dto);
            return Authors.Count;
        }

        public static void Dispose()
        {
            Authors.Clear();
        }

        public static void AddAuthors(IEnumerable<AuthorDTO> authors)
        {
            Authors.AddRange(authors);
        }

        public async Task<AuthorDTO> Get(int id)
        {
            await Task.Yield();
            return Authors.FirstOrDefault(a => a.Id == id);
        }
    }
}
