using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    /// <summary>
    /// Configuration class implementing the Singleton design pattern.
    /// Stores global application settings.
    /// </summary>
    internal class Config
    {
        private static Config? _instance;


        public string DeviceName { get; set; } = "Generic Device";
        public string Model { get; set; } = "v1.0";

   
        private Config() { }

     
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config();
                return _instance;
            }
        }
    }
}