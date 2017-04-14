using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs.BaseDto;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Manager;
using Commons.Interfaces.Repository.baseRepository;

namespace Template.BLL.Managers.BaseManager
{
    public class BaseManager:IBaseManager<BaseDto>
    {
        public IBaseRepository<BaseEntity,BaseDto> _repository;
        public BaseManager(IBaseRepository<BaseEntity, BaseDto> repository)
        {
            _repository = repository;
        }
        public IEnumerable<BaseDto> GetAll()
        {
            var result = _repository.GetAll();
            if (result.IsValid && !result.Errors.Any())
            {
                return result.Value;
            }
            return new List<BaseDto>();
        }

        public IEnumerable<BaseDto> GetAllBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            var result= _repository.GetAllBy(predicate);
            if (result.IsValid && !result.Errors.Any())
            {
                return result.Value;
            }
            return new List<BaseDto>();
        }

        public BaseDto GetBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            var result = _repository.GetFirstBy(predicate);
            if (result.IsValid && !result.Errors.Any())
            {
                return result.Value;
            }
            return new BaseDto();
        }

        public void Create(BaseDto entity)
        {
            _repository.Add(entity);
        }

        public void Delete(BaseDto entity)
        {
            _repository.Delete(entity);
        }

        public void Update(BaseDto entity)
        {
            _repository.Edit(entity);
        }
    }
}
