namespace AdvancedC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Car myCar = new Car(0);

            
            myCar.Drive(); 

          
            myCar.Refuel(34);

           
            myCar.Drive(); 

           
            IVehicle vehicle = myCar;
            vehicle.Drive();


            ////
            ///
           
                MyStack s = new MyStack(2); 

                s.Push(123);
                s.Push(2);
                s.Push(1);
            s.Pop();
            s.Pop();
            Console.WriteLine("==");
            s.Pop();


        }
    }
}
