using Lecture32_Many_To_Many.Data;
using Lecture32_Many_To_Many.Requests.Enrollment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture32_Many_To_Many.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        [HttpPost("enroll")]
        public IActionResult EnrollStudentInCourse(EnrollmentRequest req)
        {
            Baza baza = new Baza();

            var student = baza.Students.Include(s => s.Courses).FirstOrDefault(s => s.Id == req.StudentId);

            var course = student.Courses.FirstOrDefault(c => c.Id == req.CourseId);

            if (student == null || course == null)
            {
                return NotFound("Student or Course not found.");
            }

            student.Courses.Add(course);
            baza.SaveChanges();

            return Ok(new { Message = "Student enrolled in course successfully." });
        }

        [HttpDelete("unenroll")]
        public IActionResult UnenrollStudentFromCourse(EnrollmentRequest req)
        {
            Baza baza = new Baza();

            var student = baza.Students.Include(s => s.Courses).FirstOrDefault(s => s.Id == req.StudentId);
            var course = baza.Courses.FirstOrDefault(c => c.Id == req.CourseId);
            
            if (student == null || course == null)
            {
                return NotFound("Student or Course not found.");
            }
            
            student.Courses.Remove(course);
            baza.SaveChanges();
            
            return Ok(new { Message = "Student unenrolled from course successfully." });
        }
    }
}
