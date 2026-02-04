using Lecture32_Many_To_Many.Requests.Course;

namespace Lecture32_Many_To_Many.Requests.Student;

public class ReadStudent
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<CourseItem> Courses { get; set; }
}
