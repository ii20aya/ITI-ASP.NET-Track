using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_
{
    
       
        internal class Car : IVehicle, IDrivable
        {
            private int Gasoline { get; set; }

           
            public Car(int startingGas)
            {
                Gasoline = startingGas;
            }

           
            public bool Refuel(int amount)
            {
                Gasoline += amount;
                return true;
            }


        public void Move() { Console.WriteLine("Car is Moving"); }
            public void Accelerate() => Console.WriteLine("Car is Accelerating");

            
            void IVehicle.Drive()
            {
                if (Gasoline > 0)
                    Console.WriteLine("Driving (IVehicle)");
                else
                    Console.WriteLine("No gas!");
            }

           
            public void Drive()
            {
                if (Gasoline > 0)
                    Console.WriteLine("The Car is Driving at a time");
                else
                    Console.WriteLine("Out of gas, please refuel!");
            }
        }
    }

