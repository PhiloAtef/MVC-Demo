using MVCAssignment.BLL.Interfaces;
using MVCAssignment.DAL.Models;
using MVCAssignment.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCAssignment.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        //private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            //_dbContext = dbContext;  
        }
        
    }
}
