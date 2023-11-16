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
    public class CoursesController : Controller
    {
        private readonly DB_128040_practiceContext _context;

        public CoursesController(DB_128040_practiceContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
              return _context.Courses != null ? 
                          View(await _context.Courses.ToListAsync()) :
                          Problem("Entity set 'DB_128040_practiceContext.Courses'  is null.");
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        //protected override void Dispose(bool disposing)
        //{
        //  if (disposing)
        //    {
        //    _context.Dispose();
        //  }
        //  base.Dispose(disposing);
        //}

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }
    }
}
