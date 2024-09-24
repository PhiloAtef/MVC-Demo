using Microsoft.EntityFrameworkCore;
using MVCAssignment.BLL.Interfaces;
using MVCAssignment.DAL.Data;
using MVCAssignment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAssignment.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(T item)
        {
            _dbContext.Set<T>().Add(item);
            return _dbContext.SaveChanges();
        }

        public int Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public int Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            return _dbContext.SaveChanges();
        }
    }
}
