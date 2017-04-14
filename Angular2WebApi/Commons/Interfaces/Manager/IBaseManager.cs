using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs.BaseDto;
using Commons.Entities.BaseEntity;

namespace Commons.Interfaces.Manager
{
    public interface IBaseManager<T> where T : BaseDto
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllBy(Expression<Func<BaseEntity, bool>> predicate);
        T GetBy(Expression<Func<BaseEntity, bool>> predicate);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
