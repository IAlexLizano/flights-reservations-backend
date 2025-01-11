using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IFlight
    {
        string createFlight(CreateFlightDto dto);
        string updateFlight(string id, UpdateFlightDto dto);
        Flight GetFlightById(string id);
        IEnumerable<Flight> GetAll();
    }
}
