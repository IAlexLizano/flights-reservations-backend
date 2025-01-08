using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    [DataContract]
    public class OriginAirport
    {
        [DataMember]
        public int originAirportId { get; set; }
        [DataMember]
        public string originAirport { get; set; }
        [DataMember]
        public OriginCity originCityId { get; set; }
    }
}
