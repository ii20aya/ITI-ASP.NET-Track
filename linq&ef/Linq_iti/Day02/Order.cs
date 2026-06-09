using System;

public class Order
{
    public Order(int orderID, DateTime orderDate)
    {
        OrderID = orderID;
        OrderDate = orderDate;
    }

    public Order() { }

    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderLine> OrderLines { get; set; }

    public override string ToString()
    {
        return $"Order Id: {OrderID},Date: {OrderDate.ToShortTimeString()},Total: {TotalAmount}";
    }
}


