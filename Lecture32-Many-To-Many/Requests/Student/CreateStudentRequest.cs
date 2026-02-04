using Lecture32_Many_To_Many.CORE;

namespace Lecture32_Many_To_Many.Requests.Student;

public class CreateStudentRequest : BaseEntity
{
    public string FullName { get; set; }
}
