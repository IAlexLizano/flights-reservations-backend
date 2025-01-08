using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class AirlineService : IAirlineService
    {
        public IEnumerable<Airline> GetAirlines()
        {
            using (var obj = new AirlineFacade())
            {
                try
                {
                    return obj.GetAirlines();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while retrieving airlines.", ex);
                }
            }
        }

        public string AddAirline(CreateAirlineDto airlineDto)
        {
            if (string.IsNullOrWhiteSpace(airlineDto.airline))
            {
                throw new ArgumentException("Airline name is required.");
            }

            using (var obj = new AirlineFacade())
            {
                try
                {
                    return obj.AddAirline(airlineDto);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while adding the airline.", ex);
                }
            }
        }

        public string UpdateAirline(string id, UpdateAirlineDto airlineDto)
        {
            if (airlineDto == null)
            {
                throw new ArgumentException("Flight details cannot be null.");
            }

            using (var obj = new AirlineFacade())
            {
                try
                {
                    return obj.EditAirline(id, airlineDto);
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
