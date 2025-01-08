using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        public int flightId { get; set; }
        [DataMember]
        public Airline airlineId { get; set; }
        [DataMember]
        public Airport originAirportId { get; set; }
        [DataMember]
        public Airport destinationAirportId { get; set; }
        [DataMember]
        public DateTime departureDate { get; set; }
        [DataMember]
        public DateTime arrivalDate { get; set; }
        [DataMember]
        public string type { get; set; } // Primera Clase, Económica, Ejecutiva
        [DataMember]
        public decimal price { get; set; }
        [DataMember]
        public int scales { get; set; }
        [DataMember]
        public int availableSeats { get; set; }
        [DataMember]
        public bool isActive { get; set; }
    }
}
