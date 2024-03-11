using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

namespace Traveless.Models
{
	public class Reservation
	{
		public string ResCode { get; set; } = string.Empty;
		public string FlightCode { get; set; } = string.Empty;
		public string Airline { get; set; } = string.Empty;
		public string Cost {  get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Citizenship { get; set; } = string.Empty;
		public bool IsActive { get; set; } = false;

		public Reservation(string resCode, string flightCode, string airline, string cost, string name, string citizenship, bool isActive)
		{
			ResCode = resCode;
			FlightCode = flightCode;
			Airline = airline;
			Cost = cost;
			Name = name;
			Citizenship = citizenship;
			IsActive = isActive;
		}
	}

	
}
