using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.net_Final.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}