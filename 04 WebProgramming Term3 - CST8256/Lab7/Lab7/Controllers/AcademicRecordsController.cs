using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab7.Models.DataAccess;
using Microsoft.AspNetCore.Http;


namespace Lab7.Controllers
{
    public class AcademicRecordsController : Controller
    {
        private readonly StudentRecordContext _context;

        public AcademicRecordsController(StudentRecordContext context)
        {
            _context = context;
        }

        // GET: AcademicRecords/Index
        public async Task<IActionResult> Index(string sort)
        {
            ViewData["sort"] = sort; //set the last sort used

            //creating array from db to modify index view:
            var StudentRecordContext = _context.AcademicRecord.Include(a => a.CourseCodeNavigation).Include(a => a.Student);
            AcademicRecord[] records = StudentRecordContext.ToArray();
            AcademicRecord[] sortedRecords = records;

            //Re-sort the data using the last sort method the user selected (stored in the ViewData["sort"] variable)
            if (sort == "course")
            {
                sortedRecords = records.OrderBy(r => r.CourseCodeNavigation.Title).ToArray();
            }
            else //from here down, updated for lab9
            {
                sortedRecords = records.OrderBy(r => r.Student.Name).ToArray();
            }
            if (HttpContext.Session.GetString("SortOrder") == null ||
                    HttpContext.Session.GetString("SortOrder") == "Descending")
            {
                HttpContext.Session.SetString("SortOrder", "Ascending");
            }
            else
            {
                HttpContext.Session.SetString("SortOrder", "Descending");
                sortedRecords = sortedRecords.Reverse().ToArray();
            }
            return View(sortedRecords);
        }

        //POST: AcademicRecords/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string sort, [Bind("CourseCode[], StudentId[], Grade[]")] AcademicRecord[] academicRecord)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < academicRecord.Length; i++)
                {
                    try
                    {
                        //save the student's academic record
                        _context.Update(academicRecord[i]);
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        //if it fails, continue onto the next student
                        continue;
                    }
                }
            }

            ViewData["sort"] = sort; //set the last sorting used

            //creating array from db to modify index view:
            var StudentRecordContext = _context.AcademicRecord.Include(a => a.CourseCodeNavigation).Include(a => a.Student);
            AcademicRecord[] records = StudentRecordContext.ToArray();
            AcademicRecord[] sortedRecords = records;

            //Re-sort the data using the last sort method the user selected (stored in the ViewData["sort"] variable)
            if (sort == "course")
            {
                sortedRecords = records.OrderBy(r => r.CourseCodeNavigation.Title).ToArray();
            }
            else //from here down, updated for lab9
            {
                sortedRecords = records.OrderBy(r => r.Student.Name).ToArray();
            }
            if (HttpContext.Session.GetString("SortOrder") == null ||
                    HttpContext.Session.GetString("SortOrder") == "Descending")
            {
                HttpContext.Session.SetString("SortOrder", "Ascending");
            }
            else
            {
                HttpContext.Session.SetString("SortOrder", "Descending");
                sortedRecords = sortedRecords.Reverse().ToArray();
            }
            return View(sortedRecords);
        }
        

        // GET: AcademicRecords/Create
        public IActionResult Create()
        {
            var courses = (from c in _context.Course select new { Code = c.Code, Title = c.Code + " - " + c.Title }).ToList();      
            ViewData["CourseCode"] = new SelectList(courses, "Code", "Title");

            var students = (from st in _context.Student select new { Id = st.Id, Name = st.Id + " - " + st.Name }).ToList();
            ViewData["StudentId"] = new SelectList(students, "Id", "Name");
            return View();
        }

        // POST: AcademicRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseCode,StudentId,Grade")] AcademicRecord academicRecord)
        {
            if (ModelState.IsValid)
            {
                //query if student ID + courseCode already exists
                var academicExist = (from acExist in _context.AcademicRecord
                                     where string.Compare(acExist.StudentId, academicRecord.StudentId) == 0
                                     && string.Compare(acExist.CourseCode, academicRecord.CourseCode) == 0
                                     select acExist).FirstOrDefault<AcademicRecord>();

                //if academic record does not exist yet:
                if (academicExist == null)
                {
                    //adding an academic record
                    _context.Add(academicRecord);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //display error:
                    ModelState.AddModelError("", "The academic record of this course already exists!");
                }
            }

            //display updated view
            var courses = (from c in _context.Course select new { Code = c.Code, Title = c.Code + " - " + c.Title }).ToList();
            ViewData["CourseCode"] = new SelectList(courses, "Code", "Title");

            var students = (from st in _context.Student select new { Id = st.Id, Name = st.Id + " - " + st.Name }).ToList();
            ViewData["StudentId"] = new SelectList(students, "Id", "Name");
            return View();
        }

        // GET: AcademicRecords/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicRecord = await _context.AcademicRecord.FindAsync(id);
            if (academicRecord == null)
            {
                return NotFound();
            }
            ViewData["CourseCode"] = new SelectList(_context.Course, "Code", "Code", academicRecord.CourseCode);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", academicRecord.StudentId);
            return View(academicRecord);
        }

        // POST: AcademicRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseCode,StudentId,Grade")] AcademicRecord academicRecord)
        {
            if (id != academicRecord.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicRecordExists(academicRecord.StudentId))
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
            ViewData["CourseCode"] = new SelectList(_context.Course, "Code", "Code", academicRecord.CourseCode);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", academicRecord.StudentId);
            return View(academicRecord);
        }

        private bool AcademicRecordExists(string id)
        {
            return _context.AcademicRecord.Any(e => e.StudentId == id);
        }

    }
}
