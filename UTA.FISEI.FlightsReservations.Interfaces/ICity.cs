using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface ICity
    {
        IEnumerable<City> GetCities(); 
    }
}
