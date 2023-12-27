using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenericRepositoy<T> : IRepository<T> where T : class
    {

        private readonly UserManagerDbContext _context;

        public GenericRepositoy(UserManagerDbContext context)
        {

            this._context = context;
        }
       
     

        public async Task<T> AddAsync(T entity)
        {
            try
            {

                var result = _context.Add(entity);

                var rowcount = _context.SaveChanges();
                return result.Entity as T;

            }
            catch (Exception ex)
            {
                return default(T); //if any exep defualt is returned  null here
            }
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            try
            {
                var entity = _context.Find<T>(Id);
                if (entity != null)
                {
                    var result = _context.Remove(entity);
                    if (result.State == EntityState.Deleted)
                    {
                        var rowCount = _context.SaveChanges();
                        if(rowCount > 0)
                        {

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                      
                    }
                    else
                    {
                        return false; 
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow if needed
                return false; 
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var result = _context.Set<T>().ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return default(IEnumerable<T>);
                }
            }
            catch
            {
                return default(IEnumerable<T>);
            }
           
            
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                var result = _context.Set<T>().Find(id);
                if(result != null)
                {
                    return result;
                }
                else
                {
                    return default(T);
                }
               

            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {

                var result = _context.Update(entity);
                if (result.State == EntityState.Modified)
                {
                    var rowcount = _context.SaveChanges();
                    return result.Entity as T;
                }
                else { return default(T); }



            }
            catch (Exception ex)
            {
                return default(T); //if any exep defualt is returned  null here
            }
        }
    }
}
