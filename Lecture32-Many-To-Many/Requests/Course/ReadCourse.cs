using Lecture32_Many_To_Many.Requests.Student;

namespace Lecture32_Many_To_Many.Requests.Course;

public class ReadCourse
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public List<StudentItem> Students { get; set; }
}
