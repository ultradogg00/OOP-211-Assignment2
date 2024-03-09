
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

namespace Traveless.Components.Pages
{
    public partial class Flights: ComponentBase

    {
        // public selectedFlights selectdOptions = new selectedFlights();
        string deptName = string.Empty;
        string arivalName = string.Empty;
        string day = string.Empty;
        string selFlightCode = string.Empty;
        string selDeparture = string.Empty;
        string selDepartureTime = string.Empty;
        string customerName = string.Empty;
        string citizenship = string.Empty;
        
        string selAirline = string.Empty;
        double selCost ;
        public List<FlightsModel> allFlight = new List<FlightsModel>();
        public List<FlightsModel> foundflight = new List<FlightsModel>();
       
        protected override void OnInitialized()
        {
            base.OnInitialized();
            // read the file
            //wwwroot/flights.csv
            string resDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"wwwroot/Data");

            string flightsFilePath = Path.Combine(resDirectory, "flights.csv");
            string airportsFilePath = Path.Combine(resDirectory, "airports.csv");

            try
            {
                // Read the contents of the file
                string[] flightsContent = File.ReadAllLines(flightsFilePath);
                string[] airportContent = File.ReadAllLines(airportsFilePath);
                


                foreach (string line in flightsContent)
                {
                    
                    string[] data = line.Trim().Split(',');

                    FlightsModel flight = new FlightsModel(data[0], data[1], data[2], data[3], data[4], data[5], data[6] ,double.Parse(data[7]));
                    allFlight.Add(flight);
                    


                }
               
                   
              
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        public async void searchFLights(string deptName, string arivalName,string day)
        {


            foundflight.Clear();
            foreach (FlightsModel trip in allFlight) //string.Equals(deptName,trip.AirportDeptName)&& string.Equals(arivalName, trip.AirportArivName) && string.Equals(day, trip.DeportDate)
            {
                if (string.Equals(deptName,trip.AirportDeptName, StringComparison.OrdinalIgnoreCase) && string.Equals(arivalName, trip.AirportArivName, StringComparison.OrdinalIgnoreCase) && string.Equals(day, trip.DeportDate, StringComparison.OrdinalIgnoreCase))
                {
                    foundflight.Add(trip);
                    LoadSelectdFlight(trip);
                    return;


                }
                else if ((deptName== string.Empty)&& arivalName == string.Empty&& day == string.Empty)
                {
                    Random random = new Random();
                    int ranNum = random.Next(allFlight.Count);

                    foundflight.Add(allFlight[ranNum]);
                    LoadSelectdFlight(foundflight[0]);
                    return;
                    
                }
                
                

                

            }
            await Application.Current.MainPage.DisplayAlert("Wrong Airport name", "Please use a vaild Airport abrivarion valid.", "OK");




        }
        public  void LoadSelectdFlight(FlightsModel selFlight) 
        {
            selFlightCode = selFlight.FlightCode;
            selDeparture = selFlight.DeportDate;
            selDepartureTime = selFlight.DepartTime;
            selAirline = selFlight.AirlineName;
            selCost = selFlight.Cost;
            //foundflight.Clear();


        }
        
    }
}
