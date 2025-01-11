using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int clientId { get; set; }
        [DataMember]
        public string dni { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public DateTime birthDate { get; set; }
        [DataMember]
        public DateTime registrationDate { get; set; }
        [DataMember]
        public User userId { get; set; }
    }
}
