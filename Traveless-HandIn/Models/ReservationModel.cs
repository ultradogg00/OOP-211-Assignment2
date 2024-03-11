using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Models
{
	public class ReservationModel
	{
		public string Code { get; set; }
		public string Airline { get; set; }
		public string Day { get; set; }
		public string Time { get; set; }
		public string Name { get; set; }
		public string Citizenship { get; set; }	
		public bool isActive { get; set; }	

		public ReservationModel(Flight flight, string name, string citizenship)
		{
			Code = flight.FlightCode;
			Airline = flight.AirlineName;
			Day = flight.DepartDate;
			Time = flight.DepartTime;
			Name = name;
			Citizenship = citizenship;
		}

		public ReservationModel(string code, string airline, string day, string time, string name, string citizenship)
		{
			Code = code;
			Airline = airline;	
			Day = day;
			Time = time;	
			Name = name;
			Citizenship = citizenship;
		}

		public string getReservationInfo()
		{
			return $"{Code},{Airline},{Day},{Time},{Name},{Citizenship},{isActive}";
		}
	}
}
