﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using Core.Entity;

namespace FinalProject.UI.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _IEmployeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
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
        public IActionResult CreateEmployee(Employee model)
        {
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