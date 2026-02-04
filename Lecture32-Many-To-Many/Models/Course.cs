using Lecture32_Many_To_Many.CORE;

namespace Lecture32_Many_To_Many.Models;

public class Course : BaseEntity
{
    public string CourseName { get; set; }
    public List<Student> Students { get; set; }
}
