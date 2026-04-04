namespace day01
{
     class Program
    {
        static void Main()
        {
            Console.Write("Enter birth year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter birth month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter birth day: ");
            int day = int.Parse(Console.ReadLine());

            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            int years = currentYear - year;
            int months = currentMonth - month;
            int days = currentDay - day;

           
            if (days < 0)
            {
                days += 30;  
                months--;
            }

          
            if (months < 0)
            {
                months += 12; 
                years--;
            }

            Console.WriteLine("You are " + years + " years, "
                              + months + " months and "
                              + days + " days old");
        }
    }
}
