namespace Lecture34_AutoMapper.Requests;

public class CreateProductRequest
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string AdminOnly { get; set; }
}
