using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class AirlineFacade : IDisposable
    {
        private readonly IAirline _airlineRepository = new AirlineRepository();

        // Método para agregar una aerolínea
        public string AddAirline(CreateAirlineDto airlineDto)
        {
            if (string.IsNullOrWhiteSpace(airlineDto.airline))
            {
                throw new ArgumentException("The airline name cannot be empty.");
            }

            try
            {
                return _airlineRepository.addAirline(airlineDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the airline.", ex);
            }
        }

        // Método para obtener todas las aerolíneas
        public IEnumerable<Airline> GetAirlines()
        {
            try
            {
                return _airlineRepository.GetAirlines();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the airlines.", ex);
            }
        }

        public string EditAirline(string id, UpdateAirlineDto airlineDto)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(airlineDto.airline))
            {
                throw new ArgumentException("El ID de la aerolínea y el nombre no pueden estar vacíos.");
            }

            try
            {
                return _airlineRepository.updateAirline(id, airlineDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al actualizar la aerolínea.", ex);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
