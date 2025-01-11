using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class Connection
    {
        public static string getConnection()
        {
                return ConfigurationManager.ConnectionStrings["FlightsDB"].ToString();
        }
    }
}
