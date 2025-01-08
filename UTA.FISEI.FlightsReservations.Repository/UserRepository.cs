using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;
using Dapper;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class UserRepository : IUser
    {
        public User getUser(string email)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = "SELECT userId, email, password, isActive, roleId FROM Users WHERE email = @Email" +
                    " and isActive =1";
                var user = connection.QuerySingleOrDefault<User>(query, new { Email = email });
                connection.Close();
                return user;
            }
        }

        public User getUserbyId(int id)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = "SELECT userId, email, isActive, roleId FROM Users WHERE userId = @Id ";
                var user = connection.QuerySingleOrDefault<User>(query, new { Id = id });
                connection.Close();
                return user;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = "SELECT userId, email, isActive, roleId FROM Users WHERE isActive =1";
                var users = connection.Query<User>(query).ToList();
                connection.Close();
                return users;
            }
        }
    }
}
