public class OrderLine
{
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }


    public override string ToString()
    {
        return $"ProductID:{ProductID},Quantity:{Quantity},UnitPrice:{UnitPrice},LineTotal:{LineTotal}";
    }
}