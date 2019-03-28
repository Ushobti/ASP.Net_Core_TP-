using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net_Final.Data;
using ASP.net_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.net_Final.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private Task<UsersAuthen> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly UserManager<UsersAuthen> _userManager;
        private readonly UsersDbContext _context;

        public ToDoController(UsersDbContext context, UserManager<UsersAuthen> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            UsersAuthen user = await GetCurrentUserAsync();

            var test = this._context.Todo.

            return View( await _context.Todo.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var Task = await _context.Todo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Task == null)
            {
                return NotFound();
            }

            return View(Task);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskName, Description, ReleaseDate, EndDate")] ToDo Task )
        {
            if (ModelState.IsValid)
            {
                UsersAuthen user = await GetCurrentUserAsync();
                Task.User = user;
               
                _context.Add(Task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Task);
        }
    }
}