using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class AuthFacade : IDisposable
    {
        IAuth obj = new AuthRepository();
        public string login(string email, string password)
        {
            return obj.login(email, password);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
