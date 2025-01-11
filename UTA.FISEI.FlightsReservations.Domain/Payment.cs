using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UTA.FISEI.FlightsReservations.Domain
{
    [DataContract]
    public class Payment
    {
        [DataMember]
        public int paymentId { get; set; }
        [DataMember]
        public Reservation reservationId { get; set; }
        [DataMember]
        public decimal amount { get; set; }
        [DataMember]
        public DateTime paymentDate { get; set; }
        [DataMember]
        public PaymentMethod paymentMethodId { get; set; }
        [DataMember]
        public string account { get; set; }
    }
}
