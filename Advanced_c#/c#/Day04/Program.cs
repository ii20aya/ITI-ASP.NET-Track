namespace Day04
{
    internal class Program
    {
        static void Main()

            
        {

            //1
            Console.WriteLine("\n------------1----------------\n");
            List<Employee> empList = new List<Employee>
            {
                new Employee { Id = 1, Name = "Ahmed", Salary = 8000, Experience = 3 },
                new Employee { Id = 2, Name = "aya", Salary = 15000, Experience = 6 },
                new Employee { Id = 3, Name = "reem", Salary = 9000, Experience = 7 }
            };

            
            Console.WriteLine("Promoted by Experience (> 5 years):");
            var promotedByExp = Employee.Prompt(empList, e => e.Experience > 5);
            foreach (var e in promotedByExp) Console.WriteLine(e);

            Console.WriteLine("\n----------------------------\n");

          
            Console.WriteLine("Promoted by Salary (< 10000):");
            var promotedBySalary = Employee.Prompt(empList, e => e.Salary < 10000);
            foreach (var e in promotedBySalary) Console.WriteLine(e);





            //2
            Console.WriteLine("\n------------2----------------\n");

            StudentGrades manager = new StudentGrades();

           
            manager.AddStudent("omar");
            manager.AddStudent("mohammed");

         
            manager.AddGrade("omar", 85);
            manager.AddGrade("omar", 90);
            manager.AddGrade("omar", 95);
            manager.AddGrade("mohammed", 88);

          
            manager.AddGrade("Mohamed", 70);

        
            manager.DisplayAll();




            //3
                        Console.WriteLine("\n------------3----------------\n");
            Order myOrder = new Order(101);

          
            myOrder.UpdateStatus(OrderStatus.Shipped);

         
            myOrder.AddAction(OrderActions.Pack);

         
            myOrder.AddAction(OrderActions.Ship);

           
            myOrder.DisplayOrderDetails();


            //4
            Console.WriteLine("\n------------4----------------\n");
          
            TaskManager manager2 = new TaskManager();

            manager2.OnStatusChanged = (msg) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n>>> NOTIFICATION: {msg}");
                Console.ResetColor();
            };

            manager2.AddTask(new TaskItem
            {
                Id = 1,
                Title = "Final Project",
                Status = TaskStatus.Pending,
                Assignee = "Aya",
                Tags = TaskTags.Urgent | TaskTags.Work
            });

            manager2.AddTask(new TaskItem
            {
                Id = 2,
                Title = "Buy Groceries",
                Status = TaskStatus.InProgress,
                Assignee = "Aya",
                Tags = TaskTags.Personal
            });

       
                manager2.DisplayAll();

           
            Console.WriteLine("Updating Task 1...");
            manager2.UpdateStatus(1, TaskStatus.Completed);

      
            Console.WriteLine("\n--- Filtering: Urgent Tasks Only ---");
        
            var urgentOnes = manager2.FilterTasks(t => t.Tags.HasFlag(TaskTags.Urgent));

            foreach (var task in urgentOnes)
            {
                Console.WriteLine($"Found: {task.Title}");
            }
        }

    }
}