namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Number.Input = 5;

            #region Same Thread - Two Functions in One Thread (Sequential)
            //ThreadStart threadStart = Number.Factorial;
            //threadStart += Number.Sum;
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            #endregion

            #region Separate Threads - Each Function in its Own Thread 
            Thread thread1 = new Thread(Number.Factorial);
            Thread thread2 = new Thread(Number.Sum);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Both threads are done.");
            #endregion

            Console.ReadLine();
        }
    }
}
