
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models;

namespace My_Journal.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}