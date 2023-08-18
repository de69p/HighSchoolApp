using HighSchoolApp.Models;

namespace HighSchoolApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class StudentController : Controller
{
    private readonly HighSchoolContext _context;

    public StudentController(HighSchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Students.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(student);
    }

    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(student);
    }

    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null) _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
