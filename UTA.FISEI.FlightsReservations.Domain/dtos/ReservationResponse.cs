using System.Runtime.Serialization;
using System;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    [DataContract]
    public class ReservationResponse
    { 
        [DataMember]
        public int reservationId { get; set; }
        [DataMember]
        public Client clientId { get; set; }
        [DataMember]
        public Flight flightId { get; set; }
        [DataMember]
        public DateTime reservationDate { get; set; }
        [DataMember]
        public string status { get; set; } //Cancelado, Reservado
        [DataMember]
        public int numberOfPassengers { get; set; }
        [DataMember]
        public Payment paymentId { get; set; }
    }
}
