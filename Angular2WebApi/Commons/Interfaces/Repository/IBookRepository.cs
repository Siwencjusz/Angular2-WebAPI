using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs;
using Commons.Entities;
using Commons.Interfaces.Repository.baseRepository;

namespace Commons.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<Book, BookDto>
    {
    }
}
