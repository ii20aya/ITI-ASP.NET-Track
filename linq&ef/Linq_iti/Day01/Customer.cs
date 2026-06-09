using System;

public class Customer
{
    public Customer(int customerID, string companyName, string customerName)
    {
        CustomerID = customerID;
        CompanyName = companyName;
        CustomerName = customerName;
        Orders = new Order[10];
    }

    public Customer() { }

    public int CustomerID;
    public string CustomerName;
    public string CompanyName;
    public string Address;
    public string City;
    public string Region;
    public string PostalCode;
    public string Country;
    public string Phone;
    public string Fax;
    public Order[] Orders;


    public override string ToString()
    {
        return $"{CustomerID},{CompanyName},{Address}, {City} , {Region}, {PostalCode} , {Country} , {Phone} , {Fax}";
    }
}


