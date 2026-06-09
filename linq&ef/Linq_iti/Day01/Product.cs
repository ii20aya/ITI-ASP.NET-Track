using System;
public class Product: IComparable<Product>
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }

    public int CompareTo(Product? other)
    {
        return UnitPrice.CompareTo(other?.UnitPrice);
    }

    public override string ToString()
    {
        return $"ProductID:{ProductID},ProductName:{ProductName},Category:{Category},UnitPrice:{UnitPrice},UnitsInStock:{UnitsInStock}";
    }
}


