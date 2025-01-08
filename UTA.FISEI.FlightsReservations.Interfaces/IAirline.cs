using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IAirline
    {
        IEnumerable<Airline> GetAirlines();
        string addAirline(CreateAirlineDto airline);
        string updateAirline(string id, UpdateAirlineDto dto);
    }
}
