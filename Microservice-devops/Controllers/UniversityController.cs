using Microservice_project.Data;
using Microservice_project.Models;
using Microservice_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservice_project.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly UniversityDbContext _context;

    public StudentController(UniversityDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _context.Students.ToList();
        return Ok(students);
    }
}

    