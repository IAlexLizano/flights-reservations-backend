using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class CityFacade : IDisposable
    {
        ICity obj = new CityRepository();
        public IEnumerable<City> GetCities()
        {
            return obj.GetCities();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
