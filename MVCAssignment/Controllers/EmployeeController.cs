using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCAssignment.BLL.Interfaces;
using MVCAssignment.DAL.Models;
using System;

namespace MVCAssignment.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository EmployeeRepository, IWebHostEnvironment env)
        {
            _repository = EmployeeRepository;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _repository.GetAll();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                var count = _repository.Add(Employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var Employee = _repository.GetById(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(viewName, Employee);
        }

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(Employee);
            }

            try
            {
                _repository.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error occured during Employee update");
                }

                return View(Employee);
            }
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee Employee)
        {
            try
            {
                _repository.Delete(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error occured during Employee delete");
                }

                return View(Employee);
            }
        }
    }
}
