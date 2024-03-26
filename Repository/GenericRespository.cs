using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRespository<T> : IGenericRespository<T> where T : class
    {
        private QuanlybanhangContext db;
        public GenericRespository(QuanlybanhangContext dbContext)
        {
            db = dbContext;
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                var data = await db.Set<T>().AddAsync(entity);
                await db.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }

        public virtual async Task<object> getAll(int pageIndex, int pageSize)
        {
            try
            {
                var data = await db.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var total = await db.Set<T>().LongCountAsync();
                var results = new { TotalCount = total, Data = data };
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("Err", ex);
            }

        }
        public async Task<T> Delete(int id)
        {
            try
            {
                var data = await db.Set<T>().FindAsync(id);
                if (data != null)
                {
                    db.Set<T>().Remove(data);
                    await db.SaveChangesAsync();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("err", ex);
            }
        }

        public virtual async Task<T> getById(int id)
        {
            try
            {
                var data = await db.Set<T>().FindAsync(id);
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("err", ex);
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                // Assuming that 'db' is your DbContext instance
               
                db.Entry(entity).State = EntityState.Modified;

                await db.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflicts if needed
                // For example: log the error, retry, or throw a custom exception
                throw new Exception("Concurrency error occurred during update.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Handle other database update errors
                // For example: log the error, provide user-friendly message, or throw a custom exception
                throw new Exception("Error occurred during database update.", ex);
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                throw new Exception("An error occurred during the update process.", ex);
            }
        }

    }
}
