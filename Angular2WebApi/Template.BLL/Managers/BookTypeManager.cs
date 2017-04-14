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
    public class BookTypeManager<BookTypeDto> : BaseManager<BookTypeDto> where BookTypeDto : BaseDto
    {
        public BookTypeManager(IBaseRepository<BaseEntity, BaseDto> repository) : base(repository)
        {
        }
    }
}
