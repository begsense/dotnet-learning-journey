namespace APIAssignment1_Login_and_Register.Requests.Products;

public class AddProduct
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductCategory { get; set; }
    public decimal Price { get; set; }
    public double Quantity { get; set; }
}
