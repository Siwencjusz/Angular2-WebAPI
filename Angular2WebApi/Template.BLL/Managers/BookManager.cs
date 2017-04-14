using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs.BaseDto;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Repository.baseRepository;
using Template.BLL.Managers.BaseManager;

namespace Template.BLL.Managers
{
    public class BookManager<BookDto> : BaseManager<BookDto> where BookDto : BaseDto
    {
        public BookManager(IBaseRepository<BaseEntity, BaseDto> repository) : base(repository)
        {
        }
    }
}
