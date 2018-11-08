using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiinGroupManageStudents.Models;

namespace SiinGroupManageStudents.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SiinGroupManageStudentsContext _context;

        public StudentsController(SiinGroupManageStudentsContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListStudent()
        {
            return View(await _context.Student.ToListAsync());
        }

        public async Task<IActionResult> ListSubject()
        {
            return View(await _context.Mark.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error404));
            }

            var student = await _context.Student.Include(m => m.Marks)
                .FirstOrDefaultAsync(m => m.RollNumber == id);
            if (student == null)
            {
                return RedirectToAction(nameof(Error404));
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public async Task<IActionResult> Subject(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error404));
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Error404));
            }
            var mark = new Mark();
            mark.StudentRollNumber = id;
            return View(mark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subject([Bind("SubjectName,SubjectMark,StudentRollNumber")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", mark.StudentRollNumber);
            }
            return View(mark);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNumber,FullName,Email,CreatedAt,UpdatedAt,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListStudent));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error404));
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Error404));
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNumber,FullName,Email,CreatedAt,UpdatedAt,Status")] Student student)
        {
            if (id != student.RollNumber)
            {
                return RedirectToAction(nameof(Error404));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.RollNumber))
                    {
                        return RedirectToAction(nameof(Error404));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListStudent));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error404));
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.RollNumber == id);
            if (student == null)
            {
                return RedirectToAction(nameof(Error404));
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListStudent));
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.RollNumber == id);
        }
    }
}
