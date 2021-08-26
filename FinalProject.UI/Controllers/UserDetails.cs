using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.UI.Controllers
{
    public class UserDetails : Controller
    {
        private readonly IEmployeeRepository _IAuthenticateRepository;
        public UserDetails(IEmployeeRepository authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View("~/Views/Authenticate/CreateUser.cshtml");
        }
        public async Task<IActionResult> CreateUser(AuthenticateModel model)
        {
            var response = await _IAuthenticateRepository.CreateUser(model);
            if(response)
                return RedirectToAction("Index", "Home");
            return Json(response);
        }
    }
}
