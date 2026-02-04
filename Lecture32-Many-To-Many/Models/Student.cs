using Lecture32_Many_To_Many.CORE;

namespace Lecture32_Many_To_Many.Models;

public class Student : BaseEntity
{
    public string FullName { get; set; }
    public List<Course> Courses { get; set; }

}
