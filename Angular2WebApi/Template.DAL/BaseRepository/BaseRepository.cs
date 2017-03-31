using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons;
using Commons.DTOs.BaseDto;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Repository.baseRepository;

namespace Template.DAL.BaseRepository
{
    public class BaseRepository : IBaseRepository<BaseEntity, BaseDto>
    {
        // ReSharper disable once InconsistentNaming
        protected DatabaseContext _entities;

        // ReSharper disable once InconsistentNaming
        protected readonly IDbSet<BaseEntity> _dbset;

        // ReSharper disable once PublicConstructorInAbstractClass
        public BaseRepository(DatabaseContext context)
        {

            _entities = context;
            _dbset = context.Set<BaseEntity>();


        }

        public Result<IEnumerable<BaseDto>> GetAll()
        {
            try
            {
                var entities = AutoMapper.Mapper.Map<IEnumerable<BaseEntity>, IEnumerable<BaseDto>>(_dbset);
                return new Result(entities);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public Result<IEnumerable<BaseDto>> GetAllBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            try
            {
                var query = _dbset.Where(predicate).AsEnumerable();
                var mappedquery = AutoMapper.Mapper.Map<IEnumerable<BaseEntity>, IEnumerable<BaseDto>>(query);
                return mappedquery;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public Result<BaseDto> GetFirstBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            try
            {
                var query = _dbset.FirstOrDefault(predicate);
                var mappedquery = AutoMapper.Mapper.Map<BaseEntity, BaseDto>(query);
                return mappedquery;
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public Result<BaseDto> GetById(int Id)
        {
            try
            {
                var query = _dbset.Find(Id);
                var mappedquery = AutoMapper.Mapper.Map<BaseEntity, BaseDto>(query);
                return mappedquery;
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public Result<BaseDto> Add(BaseDto entity)
        {
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<BaseDto, BaseEntity>(entity);
                var addedEntity = _dbset.Add(mappedEntity);
                var entityToReturn = AutoMapper.Mapper.Map<BaseEntity, BaseDto>(addedEntity);
                return entityToReturn;
            }
            catch (Exception e)
            {

                return null;
            }
            
        }

        public Result<bool> Delete(BaseDto entity)
        {
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<BaseDto, BaseEntity>(entity);
                _dbset.Remove(mappedEntity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Result<bool> Edit(BaseDto entity)
        {
            
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<BaseDto, BaseEntity>(entity);
                _entities.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Result<bool> Save()
        {
            try
            {
                _entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
