using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace Lab_001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stringConnection = @"Server=127.0.0.1;port=3307; Database=trainstation; User Id=root; Password=Asdvfkf[jdrf11; SslMode=0";
            var tickets = new List<Ticket>();
            var Trips = new List<Trip>();
            using (MySqlConnection mysql_connection = new MySqlConnection(stringConnection))
            {

                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                MySqlDataReader mysql_result;

                mysql_query = new MySqlCommand("SELECT * FROM ticket", mysql_connection);
                mysql_connection.Open();
                mysql_result = mysql_query.ExecuteReader();

                while (mysql_result.Read())
                {
                    Ticket ticket = new Ticket();

                    ticket.Id = mysql_result.GetInt32(0);
                    ticket.FirstName = mysql_result.GetString(1);
                    ticket.LastName = mysql_result.GetString(2);
                    ticket.BoardingStation = mysql_result.GetString(3);
                    ticket.ArrivalStation = mysql_result.GetString(4);
                    ticket.TripNumber = mysql_result.GetInt32(5);
                    tickets.Add(ticket);

                }

                mysql_connection.Close();
            }
            using (MySqlConnection mysql_connection = new MySqlConnection(stringConnection))
            {
                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                MySqlDataReader mysql_result;
                mysql_query = new MySqlCommand("SELECT * FROM trips", mysql_connection);
                mysql_connection.Open();
                mysql_result = mysql_query.ExecuteReader();
                while (mysql_result.Read())
                {
                    Trip trip = new Trip();

                    trip.Id = mysql_result.GetInt32(0);
                    trip.DepartureStation = mysql_result.GetString(1);
                    trip.ArrivalStation = mysql_result.GetString(2);
                    Trips.Add(trip);
                }
                mysql_connection.Close();
                }
            Console.WriteLine("Tickets");
            for (int i = 0; i < tickets.Count; i++)
            {
                Console.WriteLine($"Id: {tickets[i].Id}\t" +
                    $"First name:{tickets[i].FirstName}\t" +
                    $"Last name: {tickets[i].LastName}\t" +
                    $"Boarding station: {tickets[i].BoardingStation}\t" +
                    $"Arrival station: {tickets[i].ArrivalStation}\t" +
                    $"Trip number: {tickets[i].TripNumber}");

            }
            Console.WriteLine("Trips");
            for (int i = 0; i < Trips.Count; i++)
            {
                Console.WriteLine($"Id: {Trips[i].Id}\t" +
                    $"Departure station:{Trips[i].DepartureStation}\t" +
                    $"Arrival station {Trips[i].ArrivalStation}\t");
            }
            Console.ReadLine();
        }
    }
}