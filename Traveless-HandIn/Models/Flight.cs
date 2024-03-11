using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Models
{
    public class Flight
    {
        // open and read file hear
        // dtrubets of of all types of file 
        // time cost day etc
        public string FlightCode {  get; set; }
        public string AirlineName { get; set; } 
        public string AirportDeptName { get; set; }
        public string AirportArivName { get; set; }
        public string DepartDate { get; set; }
        public string DepartTime { get; set; }
        public string Duration { get; set; }
        public double Cost { get; set; }

        public Flight(string Code,string airName,string portDeptName, string portArivName ,string date,string departTime,string duration, double cost) 
        { 
            FlightCode = Code;
            AirlineName = airName;
            AirportDeptName = portDeptName;
            AirportArivName = portArivName;
            DepartDate = date;
            DepartTime = departTime;
            Duration = duration;
            Cost = cost;
        }
        public string getFlightInfo()
        {
            return $"{FlightCode}, {AirlineName}, {AirportDeptName},{AirportArivName}, {DepartDate} ,{DepartTime} ,{Duration}, {Cost}";
        }

    }
}
