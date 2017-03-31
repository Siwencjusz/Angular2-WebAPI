using Commons.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs.BaseDto;

namespace Commons.Interfaces.Repository.baseRepository
{
    public interface IBaseRepository<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : BaseDto
    {
        IEnumerable<TViewModel> GetAll();
        IEnumerable<TViewModel> GetAllBy(Expression<Func<TEntity, bool>> predicate);
        TViewModel GetFirstBy(Expression<Func<TEntity, bool>> predicate);
        TViewModel GetById(int id);
        TViewModel Add(TViewModel entity);
        TViewModel Delete(TViewModel entity);
        bool Edit(TViewModel entity);
        bool Save();
    }
}
