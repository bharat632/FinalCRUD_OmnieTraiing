using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.UI.Controllers
{
    public class AuthenticateController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Authenticate/Login.cshtml");
        }

        [HttpPost]
        public IActionResult LoginUser(AuthenticateModel model)
        {
            return View("~/Views/Authenticate/Login.cshtml");
        }
    }
}
