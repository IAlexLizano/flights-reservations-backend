using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class AirportService : IAirportService
    {
        public Airport GetAirportById(string id)
        {
            if (int.TryParse(id, out int airportId))
            {
                using (var obj = new AirportFacade())
                {
                    try
                    {
                        return obj.GetAirportById(airportId);
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("An error occurred while retrieving the airport.", ex);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid ID format.");
            }
        }

        public IEnumerable<Airport> GetAirports()
        {
            using (var obj = new AirportFacade())
            {
                try
                {
                    return obj.GetAirports();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while retrieving airports.", ex);
                }
            }
        }
    }
}
