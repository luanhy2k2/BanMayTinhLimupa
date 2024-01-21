using Repository;
using Repository.Admin;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRespository<T> _repository;
        public GenericService(IGenericRespository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.Create(entity);
                if (result == null)
                {
                    throw new InvalidOperationException("Create operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while creating the entity.", ex);
            }
        }

        public async Task<T> Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "id must be positive integer");
            }
            try
            {
                var result = await _repository.Delete(id);
                if (result == null)
                {
                    throw new InvalidOperationException("Delete operation did not return a valid result");
                }
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while delete the entity", ex);
            }
        }

        public async Task<object> getAll(int pageIndex, int pageSize)
        {
            if( pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getAll(pageIndex, pageSize);
                if(result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while get all entities",ex);
            }
        }

        public async Task<T> getById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.getById(id);
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get entities", ex);
            }
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.Update(entity);
                if (result == null)
                {
                    throw new InvalidOperationException("Update operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while updating the entity.", ex);
            }
        }
    }
}
