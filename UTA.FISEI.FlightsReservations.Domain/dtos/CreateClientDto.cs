using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    public class CreateClientDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public string dni { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
    }
}
