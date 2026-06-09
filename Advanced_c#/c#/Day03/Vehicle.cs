using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Mileage { get; private set; }
        public int FuelCapacity { get; set; }

      
        public void AddMileage(params int[] miles)
        {
            foreach (int m in miles)
            {
                Mileage += m;
            }
        }

      
        public void GetFuelStatus(out string status)
        {
            if (FuelCapacity < 20)
                status = "Low Fuel!";
            else
                status = "Fuel OK";
        }

        public override string ToString() => $"ID: {Id}, Type: {Type}, Mileage: {Mileage}";
    }

 
    public class FleetManager : IEnumerable<Vehicle>
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();
        private static FleetManager? _instance;

        //  (Singleton)
        private FleetManager() { }

        public static FleetManager Instance
        {
            get
            {
                if (_instance == null) _instance = new FleetManager();
                return _instance;
            }
        }

        public void AddVehicle(Vehicle v) => _vehicles.Add(v);

      
        public Vehicle? this[int id]
        {
            get { return _vehicles.Find(v => v.Id == id); }
        }


    
        public List<Vehicle> this[string type]
        {
            get { return _vehicles.Where(v => v.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList(); }
        }
     
        public IEnumerator<Vehicle> GetEnumerator() => _vehicles.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
