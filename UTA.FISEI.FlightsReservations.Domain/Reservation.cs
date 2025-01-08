using System;
using System.Runtime.Serialization;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Reservation
    {
        [DataMember]
        public int reservationId { get; set; }
        [DataMember]
        public User userId { get; set; }
        [DataMember]
        public Flight flightId { get; set; }
        [DataMember]
        public DateTime reservationDate { get; set; }
        [DataMember]
        public string status { get; set; } //Cancelado, Reservado
        [DataMember]
        public int numberOfPassengers { get; set; }
    }

}
