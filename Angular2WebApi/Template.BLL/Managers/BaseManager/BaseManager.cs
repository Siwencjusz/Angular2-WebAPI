using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs.BaseDto;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Manager;
using Commons.Interfaces.Manager.baseManager;
using Commons.Interfaces.Repository.baseRepository;

namespace Template.BLL.Managers.BaseManager
{
    public abstract class BaseManager<T>:IBaseManager<BaseDto> where T : Commons.DTOs.BaseDto.BaseDto
    {
        public IBaseRepository<BaseEntity,BaseDto> _repository;
        public BaseManager(IBaseRepository<BaseEntity, BaseDto> repository)
        {
            _repository = repository;
        }
        public virtual IEnumerable<BaseDto> GetAll()
        {
            var result = _repository.GetAll();
            if (result.IsValid && !result.Errors.Any())
            {
                return result.Value;
            }
            return new List<BaseDto>();
        }

        public virtual IEnumerable<BaseDto> GetAllBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            var result= _repository.GetAllBy(predicate);
            if (result.IsValid && !result.Errors.Any())
            {
                return result.Value;
            }
            return new List<BaseDto>();
        }

        public virtual BaseDto GetBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            var result = _repository.GetFirstBy(predicate);
            if (result.IsValid && !result.Errors.Any())
            {
                return result.Value;
            }
            return new BaseDto();
        }

        public virtual void Create(BaseDto entity)
        {
            _repository.Add(entity);
        }

        public virtual void Delete(BaseDto entity)
        {
            _repository.Delete(entity);
        }

        public virtual void Update(BaseDto entity)
        {
            _repository.Edit(entity);
        }
    }
}
