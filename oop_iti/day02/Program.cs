using System;

namespace day02
{

    struct Employee
    {
        public int ssn;
        public string name;
        public int age;
        public float salary;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];


            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine("Enter number " + (i + 1));
            //    arr[i] = int.Parse(Console.ReadLine());
            //}



                #region min_max_Array




                //int min = arr[0];
                //int max = arr[0];


                //for (int i = 1; i < arr.Length; i++)
                //{
                //    if (arr[i] > max)
                //    {
                //        max = arr[i];
                //    }

                //    if (arr[i] < min)
                //    {
                //        min = arr[i];
                //    }
                //}


                //Console.WriteLine("Maximum value = " + max);
                //Console.WriteLine("Minimum value = " + min);

                #endregion

            Console.WriteLine("--------------------------");

            #region sort_Array



            // Bubble Sort

            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    for (int j = 0; j < arr.Length - 1 - i; j++)
            //    {
            //        if (arr[j] > arr[j + 1])
            //        {
            //            // swap
            //            int temp = arr[j];
            //            arr[j] = arr[j + 1];
            //            arr[j + 1] = temp;
            //        }
            //    }
            //}


            //Console.WriteLine("Array After Sorting:");

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}

            #endregion

            Console.WriteLine("--------------------------");

            #region Search_Array



            //Console.WriteLine("Enter number to search:");
            //int number = int.Parse(Console.ReadLine());

            //int position = -1;


            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] == number)
            //    {
            //        position = i;
            //        break;
            //    }
            //}


            //if (position == -1)
            //{
            //    Console.WriteLine("Not Found");
            //}
            //else
            //{
            //    Console.WriteLine("Found at index " + position);
            //}

            #endregion

            //    Console.WriteLine("--------------------------");


            #region 2D_Array

            //    int[,] arr2 = new int[3, 4];


            //    for (int row = 0; row < 3; row++)
            //    {
            //        for (int col = 0; col < 4; col++)
            //        {
            //            Console.WriteLine("Enter value at [" + row + "," + col + "]");
            //            arr2[row, col] = int.Parse(Console.ReadLine());
            //        }
            //    }

            //    Console.WriteLine("Matrix Data:");


            //    for (int row = 0; row < 3; row++)
            //    {
            //        for (int col = 0; col < 4; col++)
            //        {
            //            Console.Write(arr2[row, col] + " ");
            //        }
            //        Console.WriteLine();
            //    }

            #endregion

            //    Console.WriteLine("--------------------------");



            #region BD

            //int currentDay = DateTime.Now.Day;
            //int currentMonth = DateTime.Now.Month;
            //int currentYear = DateTime.Now.Year;

            //int day, month, year;


            //do
            //{
            //    Console.WriteLine("Enter year from 1980 -> 2025");
            //    year = int.Parse(Console.ReadLine());
            //}
            //while (year < 1980 || year > 2025);


            //do
            //{
            //    Console.WriteLine("Enter month 1 -> 12");
            //    month = int.Parse(Console.ReadLine());
            //}
            //while (month < 1 || month > 12);


            //int daysInMonth = 31;

            //if (month == 4 || month == 6 || month == 9 || month == 11)
            //{
            //    daysInMonth = 30;
            //}
            //else if (month == 2)
            //{
            //    if (year % 4 == 0)
            //        daysInMonth = 29;
            //    else
            //        daysInMonth = 28;
            //}


            //do
            //{
            //    Console.WriteLine("Enter day");
            //    day = int.Parse(Console.ReadLine());
            //}
            //while (day < 1 || day > daysInMonth);


            //// Calculate Age
            //int ageYear = currentYear - year;
            //int ageMonth = currentMonth - month;
            //int ageDay = currentDay - day;

            //if (ageDay < 0)
            //{
            //    ageDay += 30;
            //    ageMonth--;
            //}

            //if (ageMonth < 0)
            //{
            //    ageMonth += 12;
            //    ageYear--;
            //}

            //Console.WriteLine("You're " + ageYear + " years, " + ageMonth + " months and " + ageDay + " days");

            #endregion

            //    Console.WriteLine("--------------------------");


            //#region Simple_Calc

            //double num1, num2, result;
            //char op;
            //char choice;

            //do
            //{
            //    Console.WriteLine("Enter number 1:");
            //    num1 = double.Parse(Console.ReadLine());

            //    Console.WriteLine("Enter number 2:");
            //    num2 = double.Parse(Console.ReadLine());

            //    Console.WriteLine("Enter operator (+ - * /):");
            //    op = char.Parse(Console.ReadLine());

            //    result = 0;

            //    if (op == '+')
            //    {
            //        result = num1 + num2;
            //        Console.WriteLine(num1 + " + " + num2 + " = " + result);
            //    }
            //    else if (op == '-')
            //    {
            //        result = num1 - num2;
            //        Console.WriteLine(num1 + " - " + num2 + " = " + result);
            //    }
            //    else if (op == '*')
            //    {
            //        result = num1 * num2;
            //        Console.WriteLine(num1 + " * " + num2 + " = " + result);
            //    }
            //    else if (op == '/')
            //    {
            //        if (num2 != 0)
            //        {
            //            result = num1 / num2;
            //            Console.WriteLine(num1 + " / " + num2 + " = " + result);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Error: Cannot divide by zero");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid operator");
            //    }

            //    Console.WriteLine("Continue y or n?");
            //    choice = char.Parse(Console.ReadLine());

            //}
            //while (choice == 'y');

            //#endregion

            //    Console.WriteLine("--------------------------");

               #region Q7_Employees




            Employee[] employees = new Employee[10];
            int index;
            char ch;
            char overwrite;

            do
            {

                do
                {
                    Console.WriteLine("Choose Index 0 -> 9:");
                    index = int.Parse(Console.ReadLine());
                } while (index < 0 || index > 9);


                if (employees[index].ssn != 0)
                {
                    Console.WriteLine("Employee exists, overwrite y or n?");
                    overwrite = char.Parse(Console.ReadLine());

                    if (overwrite == 'n' || overwrite == 'N')
                    {
                        Console.WriteLine("Data not changed.\n");
                    }
                    else
                    {

                        Console.WriteLine("Enter SSN:");
                        employees[index].ssn = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Name:");
                        employees[index].name = Console.ReadLine();

                        Console.WriteLine("Enter Age:");
                        employees[index].age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Salary:");
                        employees[index].salary = float.Parse(Console.ReadLine());

                        Console.WriteLine("Data updated successfully.\n");
                    }
                }
                else
                {

                    Console.WriteLine("Enter SSN:");
                    employees[index].ssn = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Name:");
                    employees[index].name = Console.ReadLine();

                    Console.WriteLine("Enter Age:");
                    employees[index].age = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Salary:");
                    employees[index].salary = float.Parse(Console.ReadLine());

                    Console.WriteLine("Data added successfully.\n");
                }

                Console.WriteLine("Continue y or n?");
                ch = char.Parse(Console.ReadLine());

            } while (ch == 'y' || ch == 'Y');


            Console.WriteLine("\n===== Employees Data =====\n");

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].ssn != 0)
                {
                    Console.WriteLine("Employee Index: " + i);
                    Console.WriteLine("SSN: " + employees[i].ssn);
                    Console.WriteLine("Name: " + employees[i].name);
                    Console.WriteLine("Age: " + employees[i].age);
                    Console.WriteLine("Salary: " + employees[i].salary);
                    Console.WriteLine("-------------------------");
                }
            }


#endregion



        }



    }
}
