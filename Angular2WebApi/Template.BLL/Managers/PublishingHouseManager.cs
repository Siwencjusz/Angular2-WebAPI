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
    public class PublishingHouseManager<PublishingHouseDto> : BaseManager<PublishingHouseDto> where PublishingHouseDto : BaseDto
    {
        public PublishingHouseManager(IBaseRepository<BaseEntity, BaseDto> repository) : base(repository)
        {
        }
    }
}
