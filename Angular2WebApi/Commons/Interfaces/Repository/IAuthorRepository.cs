using Commons.DTOs;
using Commons.Entities;
using Commons.Interfaces.Repository.baseRepository;

namespace Commons.Interfaces.Repository
{
    public interface IAuthorRepository : IBaseRepository<Author, AuthorDto>
    {
    }
}
