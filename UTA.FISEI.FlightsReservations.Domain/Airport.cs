using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Airport
    {
        [DataMember]
        public int airportId { get; set; }
        [DataMember]
        public string airport { get; set; }
        [DataMember]
        public City cityId { get; set; }
    }
}
