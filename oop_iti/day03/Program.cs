namespace day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Complex c1 = new Complex();
            //c1.SetReal(3);
            //c1.SetImg(4);
            //Console.WriteLine(c1.Print());  

            //Complex c2 = new Complex();
            //c2.SetReal(3);
            //c2.SetImg(-4);
            //Console.WriteLine(c2.Print());  

            //Complex c3 = new Complex();
            //c3.SetReal(0);
            //c3.SetImg(1);
            //Console.WriteLine(c3.Print());  

            //Complex c4 = new Complex();
            //c4.SetReal(0);
            //c4.SetImg(-1);
            //Console.WriteLine(c4.Print());  

            //Complex c5 = new Complex();
            //c5.SetReal(0);
            //c5.SetImg(0);
            //Console.WriteLine(c5.Print());  

            //

            //Employee e1 = new Employee();

            //Console.WriteLine("Enter id");
            //e1.SetId(int.Parse(Console.ReadLine()));

            //Console.WriteLine("Enter name");
            //e1.SetName(Console.ReadLine());

            //Console.WriteLine("Enter age");
            //e1.SetAge(int.Parse(Console.ReadLine()));

            //Console.WriteLine("Enter salary");
            //e1.SetSalary(float.Parse(Console.ReadLine()));

            //Console.WriteLine(e1.Print());


            //
            Employee[] employees = new Employee[3];

            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();

                Console.WriteLine($"Employee {i + 1}");

                Console.WriteLine("Enter id");
                employees[i].SetId(int.Parse(Console.ReadLine()));

                Console.WriteLine("Enter name");
                employees[i].SetName(Console.ReadLine());

                Console.WriteLine("Enter age");
                employees[i].SetAge(int.Parse(Console.ReadLine()));

                Console.WriteLine("Enter salary");
                employees[i].SetSalary(float.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].Print());
            }
        }
    }
}
