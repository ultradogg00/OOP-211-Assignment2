
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Models
{
    public class FlightsModel
    {
        // open and read file hear
        // dtrubets of of all types of file 
        // time cost day etc
        public string FlightCode {  get; set; }
        public string AirlineName { get; set; } 
        public string AirportDeptName { get; set; }
        public string AirportArivName { get; set; }
        public string DeportDate { get; set; }
        public string DepartTime { get; set; }
        public string Durration { get; set; }
        public double Cost { get; set; }

        public FlightsModel(string Code,string airName,string portDeptName, string portArivName ,string date,string departTime,string duration, double cost) 
        { 
            FlightCode = Code;
            AirlineName = airName;
            AirportDeptName = portDeptName;
            AirportArivName = portArivName;
            DeportDate = date;
            DepartTime = departTime;
            Durration = duration;

            Cost = cost;
        }
        public string getFlightInfo()
        {
            return $"{FlightCode}, {AirlineName}, {AirportDeptName},{AirportArivName}, {DeportDate} ,{DepartTime} ,{Durration}, {Cost}";
        }

    }
}
