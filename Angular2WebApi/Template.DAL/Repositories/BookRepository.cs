using Commons.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs;
using Commons.Entities;
using Template.DAL.BaseRepository;

namespace Template.DAL.Repositories
{
    public class BookRepository:BaseRepository<Book,BookDto>
    {
        public BookRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
