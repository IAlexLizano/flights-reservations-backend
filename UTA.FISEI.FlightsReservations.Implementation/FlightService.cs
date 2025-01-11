using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class FlightService : IFlightService
    {
        public string CreateFlight(CreateFlightDto flightDto)
        {
            if (flightDto == null)
            {
                throw new ArgumentException("Flight details cannot be null.");
            }

            using (var obj = new FlightFacade())
            {
                try
                {
                    return obj.CreateFlight(flightDto);
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones específico
                    throw new ApplicationException("An error occurred while creating the flight.", ex);
                }
            }
        }

        public Flight GetFlightById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Flight ID cannot be null or empty.");
            }

            using (var obj = new FlightFacade())
            {
                try
                {
                    return obj.GetFlightById(id);
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones específico
                    throw new ApplicationException("An error occurred while retrieving the flight.", ex);
                }
            }
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            using (var obj = new FlightFacade())
            {
                try
                {
                    return obj.GetAllFlights();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones específico
                    throw new ApplicationException("An error occurred while retrieving the flights.", ex);
                }
            }
        }

        public string UpdateFlight(string id, UpdateFlightDto flightDto)
        {
            if (flightDto == null)
            {
                throw new ArgumentException("Flight details cannot be null.");
            }

            using (var obj = new FlightFacade())
            {
                try
                {
                    return obj.UpdateFlight(id, flightDto);
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones específico
                    throw new ApplicationException("An error occurred while updating the flight.", ex);
                }
            }
        }
    }
}
