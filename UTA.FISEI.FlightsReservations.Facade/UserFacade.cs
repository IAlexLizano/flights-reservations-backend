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
    public class UserFacade: IDisposable
    {
        IUser obj = new UserRepository();
        public User GetUserById(int id)
        {
            return obj.getUserbyId(id);
        }

        public IEnumerable<User> getUsers()
        {
            return obj.GetUsers();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
