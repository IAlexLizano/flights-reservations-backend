using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IUser
    {
        User getUser(string email);
        User getUserbyId(int id);
        IEnumerable<User> GetUsers();
    }
}
