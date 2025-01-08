using System;

namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    public class CreateFlightDto
    {
        public int airlineId { get; set; }
        public int originAirportId { get; set; }
        public int destinationAirportId { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public int scales { get; set; } 
        public int availableSeats { get; set; }
    }

}
