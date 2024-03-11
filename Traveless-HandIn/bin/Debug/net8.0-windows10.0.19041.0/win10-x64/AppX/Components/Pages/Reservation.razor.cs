using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveless.Models;

namespace Traveless.Components.Pages;

public partial class Reservation : ComponentBase
{
	string resCode { get; set; } = string.Empty;
	string resAirline { get; set; } = string.Empty;
	string resDepartDay { get; set; } = string.Empty;
	string resDepartureTime { get; set; } = string.Empty;
	string resName { get; set; } = string.Empty;
	string resCitizenship { get; set; } = string.Empty;
    bool resIsActive { get; set; } = false; 
    public List<ReservationModel> allReservations = new List<ReservationModel>();
    public List<ReservationModel> foundReservations = new List<ReservationModel>();


    protected override void OnInitialized()
    {
        base.OnInitialized();
        // read the file
        //wwwroot/flights.csv
        string resDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/Data");

        string reservationsFilePath = Path.Combine(resDirectory, "reservations.csv");

        try
        {
            // Read the contents of the file
            string[] reservationsContent = File.ReadAllLines(reservationsFilePath);


            foreach (string line in reservationsContent)
            {
                string[] data = line.Trim().Split(',');

                ReservationModel reservationModel= new ReservationModel(data[0], data[1], data[2], data[3], data[4], data[5]);
                allReservations.Add(reservationModel);
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur
            Console.WriteLine($"Error reading the file: {ex.Message}");
        }
    }
    public async void findReservation(string code, string airline, string name)
    {
        foundReservations.Clear();
        foreach (ReservationModel reservation in allReservations) //string.Equals(deptName,flight.AirportDeptName)&& string.Equals(arivalName, flight.AirportArivName) && string.Equals(day, flight.DeportDate)
        {
            if (string.Equals(code, reservation.Name, StringComparison.OrdinalIgnoreCase) && string.Equals(airline, reservation.Airline, StringComparison.OrdinalIgnoreCase) && string.Equals(name, reservation.Name, StringComparison.OrdinalIgnoreCase))
            {
                reservation.isActive = true;
                foundReservations.Add(reservation);
                LoadSelectdReservation(reservation);
                return;
            }
        }
        await Application.Current.MainPage.DisplayAlert("Invalid Fields", "Please enter the valid reservation codes, airline, and name.", "OK");
    }
    public void LoadSelectdReservation(ReservationModel selReservation)
    {
        resCode = selReservation.Code.Remove(2);
        resAirline = selReservation.Airline;
        resDepartDay = selReservation.Day;
        resDepartureTime = selReservation.Time;
        resName = selReservation.Name;
        resCitizenship = selReservation.Citizenship;
        resIsActive = selReservation.isActive;
    }

    public void updateReservation(string newName, string newCitizenship, bool newsIsActive)
    {
        foreach (ReservationModel reservation in allReservations)
        {
            if (reservation.Name != newName || reservation.Citizenship != newCitizenship || reservation.isActive != newsIsActive)
            {
                reservation.Name = newName;
                reservation.Citizenship = newCitizenship;
                reservation.isActive = newsIsActive;
            } 
        }
    }

}
