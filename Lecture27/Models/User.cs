using Lecture27.CORE;

namespace Lecture27.Models;

internal class User : BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsDeleted { get; set; } = false;
}