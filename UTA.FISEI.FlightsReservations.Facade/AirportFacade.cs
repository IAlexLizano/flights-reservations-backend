using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class AirportFacade : IDisposable
    {
        private readonly IAirport _airportRepository = new AirportRepository();

        // Método para obtener un aeropuerto por su ID
        public Airport GetAirportById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The airport ID must be greater than 0.");
            }

            try
            {
                return _airportRepository.getAirportByID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the airport.", ex);
            }
        }

        // Método para obtener todos los aeropuertos
        public IEnumerable<Airport> GetAirports()
        {
            try
            {
                return _airportRepository.GetAirports();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the airports.", ex);
            }
        }

        // Implementación de Dispose para liberar recursos si es necesario
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
