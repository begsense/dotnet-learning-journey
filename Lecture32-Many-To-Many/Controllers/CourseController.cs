using Lecture32_Many_To_Many.Data;
using Lecture32_Many_To_Many.Models;
using Lecture32_Many_To_Many.Requests.Course;
using Lecture32_Many_To_Many.Requests.Student;
using Lecture32_Many_To_Many.Responses.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lecture32_Many_To_Many.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    [HttpPost("create-course")]
    public IActionResult CreateCourse(CreateCourseRequest req)
    {
        Course course = new Course()
        {
            CourseName = req.CourseName
        };

        Baza baza = new Baza();

        baza.Courses.Add(course);
        baza.SaveChanges();

        var response = new CreateCourseResponse()
        {
            Id = course.Id
        };

        return Ok(response);

    }

    [HttpGet("courses-with-students")]
    public ActionResult GetCoursesWithStudents()
    {
        Baza baza = new Baza();

        var courses = baza.Courses
                        .Select(c => new ReadCourse
                        {
                            Id = c.Id,
                            CourseName = c.CourseName,
                            Students = c.Students.Select(s => new StudentItem
                            {
                                Id = s.Id,
                                FullName = s.FullName
                            }).ToList()
                        }).ToList();

        return Ok(courses);
    }

}
