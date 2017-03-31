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
        protected readonly DatabaseContext _entities;

        protected readonly IDbSet<BaseEntity> _dbset;

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
                return new Result<IEnumerable<BaseDto>>(entities);
            }
            catch (Exception e)
            {
                var failure =new  Result<IEnumerable<BaseDto>>();
                var error= new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public Result<IEnumerable<BaseDto>> GetAllBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            try
            {
                var query = _dbset.Where(predicate).AsEnumerable();
                var mappedquery = AutoMapper.Mapper.Map<IEnumerable<BaseEntity>, IEnumerable<BaseDto>>(query);
                return new Result<IEnumerable<BaseDto>>(mappedquery);
            }
            catch (Exception e)
            {
                var failure = new Result<IEnumerable<BaseDto>>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public Result<BaseDto> GetFirstBy(Expression<Func<BaseEntity, bool>> predicate)
        {
            try
            {
                var query = _dbset.FirstOrDefault(predicate);
                var mappedquery = AutoMapper.Mapper.Map<BaseEntity, BaseDto>(query);
                return new Result<BaseDto>(mappedquery);
            }
            catch (Exception e)
            {

                var failure = new Result<BaseDto>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public Result<BaseDto> GetById(int Id)
        {
            try
            {
                var query = _dbset.Find(Id);
                var mappedquery = AutoMapper.Mapper.Map<BaseEntity, BaseDto>(query);
                return new Result<BaseDto>(mappedquery);
            }
            catch (Exception e)
            {
                var failure = new Result<BaseDto>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public Result<BaseDto> Add(BaseDto entity)
        {
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<BaseDto, BaseEntity>(entity);
                var addedEntity = _dbset.Add(mappedEntity);
                var entityToReturn = AutoMapper.Mapper.Map<BaseEntity, BaseDto>(addedEntity);
                return new Result<BaseDto>(entityToReturn);
            }
            catch (Exception e)
            {
                var failure = new Result<BaseDto>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }            
        }

        public Result<bool> Delete(BaseDto entity)
        {
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<BaseDto, BaseEntity>(entity);
                _dbset.Remove(mappedEntity);
                return new Result<bool>(true);
            }
            catch (Exception e)
            {
                var failure = new Result<bool>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public Result<bool> Edit(BaseDto entity)
        {
            
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<BaseDto, BaseEntity>(entity);
                _entities.Entry(mappedEntity).State = EntityState.Modified;
                return new Result<bool>(true);
            }
            catch (Exception e)
            {
                var failure = new Result<bool>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public Result<bool> Save()
        {
            try
            {
                _entities.SaveChanges();
                return new Result<bool>(true);
            }
            catch (Exception e)
            {
                var failure = new Result<bool>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }            
        }
    }
}
