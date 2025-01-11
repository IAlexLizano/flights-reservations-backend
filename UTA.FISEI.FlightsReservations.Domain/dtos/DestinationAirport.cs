using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    [DataContract]
    public class DestinationAirport
    {
        [DataMember]
        public int destinationAirportId { get; set; }
        [DataMember]
        public string destinationAirport { get; set; }
        [DataMember]
        public DestinationCity destinationCityId { get; set; }
    }
}
