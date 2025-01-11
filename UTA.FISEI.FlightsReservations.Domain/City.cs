using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class City
    {
        [DataMember]
        public int cityId { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string city { get; set; }
    }
}
