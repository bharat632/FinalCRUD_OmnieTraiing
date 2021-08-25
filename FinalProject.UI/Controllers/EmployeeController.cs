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

        public IActionResult EmployeeList()
        {
            //var response = _IEmployeeRepository.GetEmployee();
            //return View("~/Views/Employee/EmployeeList.cshtml" , response);

            return View("~/Views/Employee/EmployeeList.cshtml");
        }

        public IActionResult EmployeeForm()
        {
            return View("~/Views/Employee/CreateEmployee.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee model , IFormFile EmpImage)
        {

            //var upload = Path.Combine(_IHostingEnvironment.WebRootPath, "ProfileImages\\");
            //using (FileStream fs = new FileStream(Path.Combine(upload , EmpImage.FileName ) , FileMode.Create))
            //{
            //    await EmpImage.CopyToAsync(fs);
            //}

            //return Json("");

            var response = _IEmployeeRepository.CreateEmployee(model);
            return View("~/Views/Employee/EmployeeList.cshtml");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var response = _IEmployeeRepository.DeleteEmployee(id);
            return Json(response);
        }
    }
}
