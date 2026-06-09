namespace Assignment1
{
    internal class Number
    {
        public static int Input { get; set; } = 0;
        public static int FactorialOutput { get; set; } = 1;
        public static int SumOutput { get; set; } = 0;

        public static void Factorial()
        {
            Thread.Sleep(3000);
            FactorialOutput = 1;
            for (int i = Input; i > 1; i--)
            {
                FactorialOutput *= i;
            }
            Console.WriteLine($"Factorial of {Input} = {FactorialOutput}");
        }

        public static void Sum()
        {
            SumOutput = 0;
            for (int i = 1; i <= Input; i++)
            {
                SumOutput += i;
            }
            Console.WriteLine($"Sum from 1 to {Input} = {SumOutput}");
        }
    }
}
