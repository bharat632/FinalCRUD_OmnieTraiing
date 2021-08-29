using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FinalProject.UI.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _IEmployeeRepository;
        private readonly IHostingEnvironment _IHostingEnvironment;

        public EmployeeController(IEmployeeRepository employeeRepository , IHostingEnvironment hostingEnvironment)
        {
            _IHostingEnvironment = hostingEnvironment;
            _IEmployeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var response = await _IEmployeeRepository.GetEmployee();
            return View("~/Views/Employee/EmployeeList.cshtml" , response);
        }

        public IActionResult EmployeeForm()
        {
            return View("~/Views/Employee/CreateEmployee.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee model, IFormFile EmpImage)
        {
            var upload = Path.Combine(_IHostingEnvironment.WebRootPath, "ProfileImages//");
            using (FileStream fs = new FileStream(Path.Combine(upload , EmpImage.FileName ) , FileMode.Create))
            {
                await EmpImage.CopyToAsync(fs);
                model.EmpImage = fs.Name;
            }
            var response = _IEmployeeRepository.CreateEmployee(model);
            return RedirectToAction("EmployeeList", "Employee");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var response = _IEmployeeRepository.DeleteEmployee(id);
            return Json(response);
        }
    }
}
