﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IAirport
    {
        IEnumerable<Airport> GetAirports();
        Airport getAirportByID(int id);
    }
}