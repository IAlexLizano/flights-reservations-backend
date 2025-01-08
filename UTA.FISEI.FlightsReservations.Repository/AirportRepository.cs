using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class AirportRepository : IAirport
    {
        // Método para obtener un aeropuerto por su ID
        public Airport getAirportByID(int airportId)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        SELECT 
                            a.airportId, a.airport, 
                            c.cityId, c.country, c.city
                        FROM Airports a
                        INNER JOIN Cities c ON a.cityId = c.cityId
                        WHERE a.airportId = @AirportId
                    ";

                    var airport = connection.Query<Airport, City, Airport>(
                        query,
                        (a, c) =>
                        {
                            a.cityId = c;
                            return a;
                        },
                        new { AirportId = airportId },
                        splitOn: "cityId"
                    ).FirstOrDefault();

                    return airport;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el aeropuerto: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Método para obtener todos los aeropuertos
        public IEnumerable<Airport> GetAirports()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        SELECT 
                            a.airportId, a.airport, 
                            c.cityId, c.country, c.city
                        FROM Airports a
                        INNER JOIN Cities c ON a.cityId = c.cityId
                    ";

                    var airports = connection.Query<Airport, City, Airport>(
                        query,
                        (a, c) =>
                        {
                            a.cityId = c;
                            return a;
                        },
                        splitOn: "cityId"
                    ).ToList();

                    return airports;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los aeropuertos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
