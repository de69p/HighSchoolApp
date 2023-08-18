using HighSchoolApp.Models;

namespace HighSchoolApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TeacherController : Controller
{
    private readonly HighSchoolContext _context;

    public TeacherController(HighSchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Teachers.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var teacher = _context.Teachers.Find(id);
        return View(teacher);
    }

    [HttpPost]
    public IActionResult Edit(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var teacher = _context.Teachers.Find(id);
        return View(teacher);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher != null) _context.Teachers.Remove(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
