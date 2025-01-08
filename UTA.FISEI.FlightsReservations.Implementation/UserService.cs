using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class UserService : IUserService
    {
        public User getUserById(string id)
        {
            if (int.TryParse(id, out int userId))
            {
                using (var obj = new UserFacade()) 
                {
                    return obj.GetUserById(userId);
                }
            }
            else
            {
                throw new ArgumentException("Invalid ID format.");
            }
        }

        public IEnumerable<User> getUsers()
        {
            using (var obj = new UserFacade())
            {
                return obj.getUsers();
            }
        }
    }
}
