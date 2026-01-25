namespace Lecture30_CRUD.Requests.Products;

public class EditProduct
{
    public int Id { get; set; }
    public string NewTitle { get; set; }
    public decimal NewPrice { get; set; }
}
