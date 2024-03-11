using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveless.Models;
using System.IO;

namespace Traveless.Components.Pages
{
    public partial class Flights : ComponentBase
    {
        // public selectedFlights selectdOptions = new selectedFlights();
        string deptName = string.Empty;
        string arivalName = string.Empty;
        string day = string.Empty;
        string selFlightCode = string.Empty;
        string selDeparture = string.Empty;
        string selDepartureTime = string.Empty;
        string customerName = string.Empty;
        string custCitizenship = string.Empty;
        string selAirline = string.Empty;
        double selCost;
        public List<Flight> allFlights = new List<Flight>();
        public List<Flight> foundflight = new List<Flight>();


        protected override void OnInitialized()
        {
            base.OnInitialized();
            // read the file
            //wwwroot/flights.csv
            string resDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/Data");

            string flightsFilePath = Path.Combine(resDirectory, "flights.csv");
            string airportsFilePath = Path.Combine(resDirectory, "airports.csv");
            string reservationsFilePath = Path.Combine(resDirectory, "reservations.csv");

            try
            {
                // Read the contents of the file
                string[] flightsContent = File.ReadAllLines(flightsFilePath);
                string[] airportContent = File.ReadAllLines(airportsFilePath);
				

				foreach (string line in flightsContent)
                {
                    string[] data = line.Trim().Split(',');

                    Flight flight = new Flight(data[0], data[1], data[2], data[3], data[4], data[5], data[6], double.Parse(data[7]));
                    allFlights.Add(flight);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        // fill in the flight details
        public async void fillFields(string deptName, string arivalName, string day)
        {
            foundflight.Clear();
            foreach (Flight flight in allFlights) //string.Equals(deptName,flight.AirportDeptName)&& string.Equals(arivalName, flight.AirportArivName) && string.Equals(day, flight.DeportDate)
            {
                if (string.Equals(deptName, flight.AirportDeptName, StringComparison.OrdinalIgnoreCase) && string.Equals(arivalName, flight.AirportArivName, StringComparison.OrdinalIgnoreCase) && string.Equals(day, flight.DepartDate, StringComparison.OrdinalIgnoreCase))
                {
                    foundflight.Add(flight);
                    LoadSelectdFlight(flight);
					return;
				}
                else if ((deptName == string.Empty) && arivalName == string.Empty && day == string.Empty)
                {
                    Random random = new Random();
                    int ranNum = random.Next(allFlights.Count);

                    foundflight.Add(allFlights[ranNum]);
                    LoadSelectdFlight(foundflight[0]);
					return;
				}
            }
			await Application.Current.MainPage.DisplayAlert("Invalid Fields", "Please enter the valid airport codes and day.", "OK");
		}

        // select a flight
        public void LoadSelectdFlight(Flight selFlight)
        {
            selFlightCode = selFlight.FlightCode;
            selDeparture = selFlight.DepartDate;
            selDepartureTime = selFlight.DepartTime;
            selAirline = selFlight.AirlineName;
            selCost = selFlight.Cost;
        }

        // make the reservation
        public async void makeReservation(Flight selFlight, string name, string citizenship)
		{
			if (customerName == string.Empty || custCitizenship == string.Empty)
			{
				await Application.Current.MainPage.DisplayAlert("Name or Citizenship fields are empty.", "Please enter your name and citizenship.", "OK");
			}

            ReservationModel newRes = new ReservationModel(selFlight, name, citizenship);

            // write to reservations.csv:
            string resDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/Data");
            string reservationsFilePath = Path.Combine(resDirectory, "reservations.csv");

            string fileName = reservationsFilePath;
            string input = newRes.getReservationInfo();
            File.AppendAllText(fileName, input);
		}
    }
}
