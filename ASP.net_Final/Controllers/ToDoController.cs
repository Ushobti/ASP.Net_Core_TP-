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

            return View( await _context.Todo.Where(t => t.User ==  user).ToListAsync());
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var Task = await _context.Todo.FindAsync(id);

            if (Task == null)
            {
                return NotFound();
            }

            return View(Task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID,[Bind("ID, TaskName, Description, ReleaseDate, EndDate")] ToDo Task)
        {

            if (ID != Task.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(Task.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var Task = await _context.Todo.FirstOrDefaultAsync(m => m.ID == id);

            if (Task == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ToDo Task = await _context.Todo.FindAsync(id);
            _context.Todo.Remove(Task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Todo.Any(e => e.ID == id);
        }
    }
}