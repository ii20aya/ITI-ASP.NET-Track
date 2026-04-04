namespace day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Queue 

            //Queue q = new Queue(3);



            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);   // Full

            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());   // Empty

            //Console.WriteLine();

            #endregion



            #region Stack 

            //DynamicStack s = new DynamicStack(3);

            //Console.WriteLine("----- Stack Test -----");

            //s.Push(10);
            //s.Push(20);
            //s.Push(30);
            //s.Push(40);   // Full

            //Console.WriteLine(s.Pop());
            //Console.WriteLine(s.Pop());
            //Console.WriteLine(s.Pop());
            //Console.WriteLine(s.Pop());   // Empty

            //Console.WriteLine();

            #endregion



            #region Complex 

            Complex c1 = new Complex(3, 4);
            Complex c2 = new Complex(1, 2);

            Console.WriteLine("----- Complex Test -----");

            Complex c3 = c1 + c2;
            c3.Print();

            Complex c4 = c1 + 5;
            c4.Print();

            Complex c5 = 5 + c1;
            c5.Print();

            c1++;
            c1.Print();

            if (c1 > c2)
            {
                Console.WriteLine("c1 > c2");
            }

            int x = (int)c1;
            Console.WriteLine(x);

            #endregion
        }
    }
}
