using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IAuth
    {
        string login(string username, string password);
    }
}
