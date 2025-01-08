using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class FlightRepository : IFlight
    {
        // Método para crear un vuelo
        public string createFlight(CreateFlightDto dto)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        INSERT INTO Flights (
                            airlineId, originAirportId, destinationAirportId, 
                            departureDate, arrivalDate, type, price, scales, availableSeats
                        ) 
                        VALUES (
                            @AirlineId, @OriginAirportId, @DestinationAirportId, 
                            @DepartureDate, @ArrivalDate, @Type, @Price, @Scales, @AvailableSeats
                        );
                    ";

                    connection.Execute(query, new
                    {
                        AirlineId = dto.airlineId,
                        OriginAirportId = dto.originAirportId,
                        DestinationAirportId = dto.destinationAirportId,
                        DepartureDate = dto.departureDate,
                        ArrivalDate = dto.arrivalDate,
                        Type = dto.type,
                        Price = dto.price,
                        Scales = dto.scales,
                        AvailableSeats = dto.availableSeats
                    });

                    return "Vuelo creado exitosamente.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al crear el vuelo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Método para obtener todos los vuelos
        public IEnumerable<Flight> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        SELECT 
                            f.flightId, f.departureDate, f.arrivalDate, f.type, 
                            f.price, f.scales, f.availableSeats, f.isActive,
                            a.airlineId, a.airline, a.code,
                            oa.airportId AS originAirportId, oa.airport AS originAirport, 
                            da.airportId AS destinationAirportId, da.airport AS destinationAirport,
                            oa.cityId AS originCityId, c1.city AS originCity, c1.country AS originCountry,
                            da.cityId AS destinationCityId, c2.city AS destinationCity, c2.country AS destinationCountry
                        FROM Flights f
                        INNER JOIN Airlines a ON f.airlineId = a.airlineId
                        INNER JOIN Airports oa ON f.originAirportId = oa.airportId
                        INNER JOIN Airports da ON f.destinationAirportId = da.airportId
                        INNER JOIN Cities c1 ON oa.cityId = c1.cityId
                        INNER JOIN Cities c2 ON da.cityId = c2.cityId
                    ";

                    var flights = connection.Query<Flight, Airline, OriginAirport, DestinationAirport, OriginCity, DestinationCity, Flight>(
                     query,
                        (flight, airline, origin, destination, originCity, destinationCity) =>
                        {
                         
                             flight.airlineId = airline;
                             flight.originAirportId = new Airport { airportId= origin.originAirportId, airport= origin.originAirport, cityId = new City {cityId = originCity.originCityId, city= originCity.originCity, country= originCity.originCountry} };
                             flight.destinationAirportId = new Airport { airportId = destination.destinationAirportId, airport = destination.destinationAirport, 
                                 cityId = new City { cityId = destinationCity.destinationCityId, city = destinationCity.destinationCity, country = destinationCity.destinationCountry } };
                            return flight;
                     },
                     splitOn: "airlineId,originAirportId,destinationAirportId,originCityId,destinationCityId"
                 ).ToList();

                    return flights;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los vuelos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Método para obtener un vuelo por ID
        public Flight GetFlightById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        SELECT 
                            f.flightId, f.departureDate, f.arrivalDate, f.type, 
                            f.price, f.scales, f.availableSeats, f.isActive,
                            a.airlineId, a.airline, a.code,
                            oa.airportId AS originAirportId, oa.airport AS originAirport, 
                            da.airportId AS destinationAirportId, da.airport AS destinationAirport,
                            oa.cityId AS originCityId, c1.city AS originCity, c1.country AS originCountry,
                            da.cityId AS destinationCityId, c2.city AS destinationCity, c2.country AS destinationCountry
                        FROM Flights f
                        INNER JOIN Airlines a ON f.airlineId = a.airlineId
                        INNER JOIN Airports oa ON f.originAirportId = oa.airportId
                        INNER JOIN Airports da ON f.destinationAirportId = da.airportId
                        INNER JOIN Cities c1 ON oa.cityId = c1.cityId
                        INNER JOIN Cities c2 ON da.cityId = c2.cityId
                        WHERE f.flightId = @FlightId
                    ";

                    var flight = connection.Query<Flight, Airline, OriginAirport, DestinationAirport, OriginCity, DestinationCity, Flight>(
                        query,
                        (f, airline, origin, destination, originCity, destinationCity) =>
                        {
                            f.airlineId = airline;
                            f.originAirportId = new Airport { airportId = origin.originAirportId, airport = origin.originAirport, cityId = new City { cityId = originCity.originCityId, city = originCity.originCity, country = originCity.originCountry } };
                            f.destinationAirportId = new Airport
                            {
                                airportId = destination.destinationAirportId,
                                airport = destination.destinationAirport,
                                cityId = new City { cityId = destinationCity.destinationCityId, city = destinationCity.destinationCity, country = destinationCity.destinationCountry }
                            };
                            return f;
                        },
                        new { FlightId = id },
                        splitOn: "airlineId,originAirportId,destinationAirportId,originCityId,destinationCityId"
                    ).FirstOrDefault();

                            return flight;
                        }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el vuelo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Método para actualizar un vuelo
        public string updateFlight(string id, UpdateFlightDto dto)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        UPDATE Flights
                        SET 
                            airlineId = @AirlineId,
                            departureDate = @DepartureDate,
                            arrivalDate = @ArrivalDate,
                            type = @Type,
                            price = @Price,
                            scales = @Scales,
                            availableSeats = @AvailableSeats
                        WHERE flightId = @FlightId
                    ";

                    connection.Execute(query, new
                    {
                        AirlineId = dto.airlineId,
                        DepartureDate = dto.departureDate,
                        ArrivalDate = dto.arrivalDate,
                        Type = dto.type,
                        Price = dto.price,
                        Scales = dto.scales,
                        AvailableSeats = dto.availableSeats,
                        FlightId= id
                    });

                    return "Vuelo actualizado exitosamente.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el vuelo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
