using HighSchoolApp.Models;

namespace HighSchoolApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ExamController : Controller
{
    private readonly HighSchoolContext _context;

    public ExamController(HighSchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var validStudentIds = _context.Students.Select(s => s.StudentId).ToList();
        var exams = _context.Exams.Where(e => validStudentIds.Contains(e.StudentId)).ToList();
        return View(exams);
    }


    public IActionResult Create()
    {
        ViewBag.StudentIds = _context.Students.Select(s => s.StudentId).ToList();
        return View();
    }


    [HttpPost]
    public IActionResult Create(Exam exam)
    {
        if (ModelState.IsValid)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(exam);
    }

    public IActionResult Edit(int id)
    {
        var exam = _context.Exams.Find(id);
        if (exam == null)
        {
            return NotFound();
        }
        return View(exam);
    }

    [HttpPost]
    public IActionResult Edit(Exam exam)
    {
        if (ModelState.IsValid)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(exam);
    }

    public IActionResult Delete(int id)
    {
        var exam = _context.Exams.Find(id);
        if (exam == null)
        {
            return NotFound();
        }
        return View(exam);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var exam = _context.Exams.Find(id);
        if (exam != null) _context.Exams.Remove(exam);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Report()
    {
        var exams = _context.Exams.ToList();

        var report = new GradeReport
        {
            ACount = exams.Count(e => e.Score >= 90),
            BCount = exams.Count(e => e.Score >= 80 && e.Score < 90),
            CCount = exams.Count(e => e.Score >= 70 && e.Score < 80),
            DCount = exams.Count(e => e.Score >= 60 && e.Score < 70),
            FCount = exams.Count(e => e.Score < 60)
        };

        return View(report);
    }

}
