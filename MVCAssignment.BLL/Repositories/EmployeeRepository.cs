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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        //private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            //_dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            return _dbContext.Employees.Where(e => e.Address.ToLower().Contains(address.ToLower()));
        }
    }
}
