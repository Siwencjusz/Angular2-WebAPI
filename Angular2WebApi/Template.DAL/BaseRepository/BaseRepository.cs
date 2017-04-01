using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Commons;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Repository.baseRepository;
using Commons.DTOs.BaseDto;

namespace Template.DAL.BaseRepository
{
    public   abstract  class BaseRepository<T, TDto> : IBaseRepository<T, TDto> where T : BaseEntity where TDto : BaseDto
    {
        protected readonly DatabaseContext _entities;

        protected readonly IDbSet<T> _dbset;

        public BaseRepository(DatabaseContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual Result<IEnumerable<TDto>> GetAll()
        {
            try
            {
                var entities = AutoMapper.Mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(_dbset);
                return new Result<IEnumerable<TDto>>(entities);
            }
            catch (Exception e)
            {
                var failure =new  Result<IEnumerable<TDto>>();
                var error= new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public virtual Result<IEnumerable<TDto>> GetAllBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var query = _dbset.Where(predicate).AsEnumerable();
                var mappedquery = AutoMapper.Mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(query);
                return new Result<IEnumerable<TDto>>(mappedquery);
            }
            catch (Exception e)
            {
                var failure = new Result<IEnumerable<TDto>>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public virtual Result<TDto> GetFirstBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var query = _dbset.FirstOrDefault(predicate);
                var mappedquery = AutoMapper.Mapper.Map<T, TDto>(query);
                return new Result<TDto>(mappedquery);
            }
            catch (Exception e)
            {

                var failure = new Result<TDto>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public virtual Result<TDto> GetById(int Id)
        {
            try
            {
                var query = _dbset.Find(Id);
                var mappedquery = AutoMapper.Mapper.Map<T, TDto>(query);
                return new Result<TDto>(mappedquery);
            }
            catch (Exception e)
            {
                var failure = new Result<TDto>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }
        }

        public virtual Result<TDto> Add(TDto entity)
        {
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<TDto, T>(entity);
                var addedEntity = _dbset.Add(mappedEntity);
                var entityToReturn = AutoMapper.Mapper.Map<T, TDto>(addedEntity);
                return new Result<TDto>(entityToReturn);
            }
            catch (Exception e)
            {
                var failure = new Result<TDto>();
                var error = new Error();
                error.ErrorMessage = e.Message;
                failure.Errors.Add(error);
                return failure;
            }            
        }

        public virtual Result<bool> Delete(TDto entity)
        {
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<TDto, T>(entity);
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

        public virtual Result<bool> Edit(TDto entity)
        {
            
            try
            {
                var mappedEntity = AutoMapper.Mapper.Map<TDto, T>(entity);
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

        public virtual Result<bool> Save()
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
