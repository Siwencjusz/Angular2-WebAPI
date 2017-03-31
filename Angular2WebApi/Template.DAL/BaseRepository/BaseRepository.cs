using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs.BaseDto;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Repository.baseRepository;

namespace Template.DAL.BaseRepository
{
    public class BaseRepository:IBaseRepository<BaseEntity,BaseDto>
    {
        public IEnumerable<BaseDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseDto> GetAllBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public BaseDto GetFirstBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public BaseDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseDto Add(BaseDto entity)
        {
            throw new NotImplementedException();
        }

        public BaseDto Delete(BaseDto entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(BaseDto entity)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
