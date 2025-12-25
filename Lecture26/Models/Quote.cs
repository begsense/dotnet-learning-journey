using Lecture26.CORE;

namespace Lecture26.Models;

internal class Quote : BaseEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
}
