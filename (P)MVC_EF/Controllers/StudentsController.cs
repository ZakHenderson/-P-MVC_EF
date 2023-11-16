using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _P_MVC_EF.Models;

namespace _P_MVC_EF.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DB_128040_practiceContext _context;

        public StudentsController(DB_128040_practiceContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
              return _context.Students != null ? 
                          View(await _context.Students.ToListAsync()) :
                          Problem("Entity set 'DB_128040_practiceContext.Students'  is null.");
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        //protected override void Dispose(bool disposing)
        //{
        //  if (disposing)
        //    {
        //    _context.Dispose();
        //  }
        //  base.Dispose(disposing);
        //}
        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
