namespace Lecture25.CORE;

internal class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastModified {  get; set; }
}
