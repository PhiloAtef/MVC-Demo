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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Employee Employee)
        {
            _dbContext.Employees.Add(Employee);
            return _dbContext.SaveChanges();
        }

        public int Delete(Employee Employee)
        {
            _dbContext.Employees.Remove(Employee);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.AsNoTracking().ToList();
        }

        public Employee GetById(int id)
        {
            return _dbContext.Find<Employee>(id);
        }

        public int Update(Employee Employee)
        {
            _dbContext.Employees.Update(Employee);
            return _dbContext.SaveChanges();
        }
    }
}
