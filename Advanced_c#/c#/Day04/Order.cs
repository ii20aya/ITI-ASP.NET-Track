using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{

    public enum OrderStatus
    {
        Pending,//0
        Shipped,//1
        Delivered,//2
        Canceled//3
    }

   
    [Flags]
    public enum OrderActions : byte
    {
        None = 0,
        Pack = 1,    // 0001
        Ship = 2,    // 0010
        Deliver = 4, // 0100
        Cancel = 8   // 1000
    }


    internal class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderActions Actions { get; set; }

        public Order(int id)
        {
            OrderId = id;
            Status = OrderStatus.Pending;
            Actions = OrderActions.None;
        }

  
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"[Order {OrderId}]: Status updated to {Status}");
        }

     
        public void AddAction(OrderActions action)
        {
         //oring
            Actions |= action;
            Console.WriteLine($"[Order {OrderId}]: Added action {action}. Current actions: {Actions}");
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Current Status: {Status}");
            Console.WriteLine($"Actions Performed: {Actions}");
            Console.WriteLine("----------------------------------");
        }
    }
}