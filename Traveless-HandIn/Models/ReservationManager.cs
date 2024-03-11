using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Models
{
    public class ReservationManager
    {

        public ReservationManager(Flight flight) { }

        public string generateCode(string flightCode)
        {
            flightCode.Remove(2,1);
            return flightCode;
        }
	}
}