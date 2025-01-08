using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class CityService : ICityService
    {
        public IEnumerable<City> GetCities()
        {
            using (var obj = new CityFacade())
            {
                return obj.GetCities();
            }
        }
    }
}
