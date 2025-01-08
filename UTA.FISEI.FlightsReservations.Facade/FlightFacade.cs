using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class FlightFacade : IDisposable
    {
        IFlight obj = new FlightRepository();

        public IEnumerable<Flight> GetAllFlights()
        {
            return obj.GetAll();
        }

        public Flight GetFlightById(string id)
        {
            return obj.GetFlightById(id);
        }

        public string CreateFlight(CreateFlightDto flightDto)
        {
            if (flightDto == null)
            {
                throw new ArgumentNullException(nameof(flightDto), "Flight data is required.");
            }

            return obj.createFlight(flightDto);
        }

        public string UpdateFlight(string id, UpdateFlightDto flightDto)
        {
            if (flightDto == null)
            {
                throw new ArgumentNullException(nameof(flightDto), "Flight data is required.");
            }

            return obj.updateFlight(id, flightDto);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
