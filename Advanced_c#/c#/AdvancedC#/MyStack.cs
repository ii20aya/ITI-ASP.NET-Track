using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_
{

  
        internal class MyStack : IStack
        {
            private int[] items; 
            private int top;    

       
            public MyStack(int size)
            {
                items = new int[size];
                top = -1;
            }

           
            public void Push(int value)
            {
                
                if (top == items.Length - 1)
                {
                    Console.WriteLine("Stack is Full!");
                    return;
                }

                top++;           
                items[top] = value; 
                Console.WriteLine($"Pushed: {value}");
            }

           
            public int Pop()
            {
              
                if (top == -1)
                {
                    Console.WriteLine("Stack is Empty!");
                    return -1; 
                }

                int value = items[top]; 
                top--;                
                return value;          
            }
        }
    }