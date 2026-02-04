using Lecture32_Many_To_Many.Requests.Student;
using Lecture32_Many_To_Many.Responses.Student;
using Lecture32_Many_To_Many.Data;
using Lecture32_Many_To_Many.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lecture32_Many_To_Many.Requests.Course;

namespace Lecture32_Many_To_Many.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    [HttpPost("create-student")]
    public IActionResult CreateStudent(CreateStudentRequest req)
    {
        Student student = new Student()
        {
            FullName = req.FullName
        };

        Baza baza = new Baza();

        baza.Students.Add(student);
        baza.SaveChanges();

        var response = new CreateStudentResponse()
        {
            Id = student.Id
        };

        return Ok(response);

    }

    [HttpGet("get-all-students-courses")]
    public ActionResult GetAllStudentsCourses()
    {
        Baza baza = new Baza();
        var students = baza.Students.Include(s => s.Courses)
                        .Select(s => new ReadStudent
                        {
                            Id = s.Id,
                            FullName = s.FullName,
                            Courses = s.Courses.Select(c => new CourseItem
                            {
                                Id = c.Id,
                                Name = c.CourseName,
                            }).ToList()
                        }).ToList();

        return Ok(students);
    }
}
