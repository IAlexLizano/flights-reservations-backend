using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Airline
    {
        [DataMember]
        public int airlineId { get; set; }
        [DataMember]
        public string airline { get; set; }
        [DataMember]
        public string code { get; set; }
    }
}
