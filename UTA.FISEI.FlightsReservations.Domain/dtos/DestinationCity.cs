using System.Runtime.Serialization;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    [DataContract]
    public class DestinationCity
    {
        [DataMember]
        public int destinationCityId { get; set; }
        [DataMember]
        public string destinationCountry { get; set; }
        [DataMember]
        public string destinationCity { get; set; }
    }
}
