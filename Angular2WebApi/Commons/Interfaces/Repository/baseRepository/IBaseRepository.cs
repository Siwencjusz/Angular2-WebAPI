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
        Result<IEnumerable<TViewModel>> GetAll();
        Result<IEnumerable<TViewModel>> GetAllBy(Expression<Func<TEntity, bool>> predicate);
        Result<TViewModel> GetFirstBy(Expression<Func<TEntity, bool>> predicate);
        Result<TViewModel> GetById(int Id);
        Result<TViewModel> Add(TViewModel entity);
        Result<bool> Delete(TViewModel entity);
        Result<bool> Edit(TViewModel entity);
        Result<bool> Save();
    }
}
