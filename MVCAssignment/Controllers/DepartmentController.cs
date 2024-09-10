using Microsoft.AspNetCore.Mvc;
using MVCAssignment.BLL.Interfaces;

namespace MVCAssignment.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }
        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments);
        }
    }
}

