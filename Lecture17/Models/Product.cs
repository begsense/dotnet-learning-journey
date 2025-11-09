namespace Lecture17.Models;

public class Product

{

    private string _productName;

    private decimal _price;

    private bool _isAvailable;

    private int _quantityInStock;

    private double _rating;

    public string ProductName

    {

        get => _productName;

        set => _productName = value;

    }

    public decimal Price

    {

        get => _price;

        set => _price = value;

    }

    public bool IsAvailable

    {

        get => _isAvailable;

        set => _isAvailable = value;

    }

    public int QuantityInStock

    {

        get => _quantityInStock;

        set => _quantityInStock = value;

    }

    public double Rating

    {

        get => _rating;

        set => _rating = value;

    }

}

