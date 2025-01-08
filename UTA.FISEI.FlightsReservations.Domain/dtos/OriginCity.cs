using System.Runtime.Serialization;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    [DataContract]
    public class OriginCity
    {
        [DataMember]
        public int originCityId { get; set; }
        [DataMember]
        public string originCountry { get; set; }
        [DataMember]
        public string originCity { get; set; }
    }
}
