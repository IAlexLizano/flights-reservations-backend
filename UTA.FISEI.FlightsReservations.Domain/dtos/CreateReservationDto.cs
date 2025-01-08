namespace UTA.FISEI.FlightsReservations.Domain.dtos
{
    public class CreateReservationDto
    {
        public int userId { get; set; }
        public int flightId { get; set; }
        public int numberOfPassengers { get; set; } 
        public string status { get; set; } = "Reservado";
        public decimal amount { get; set; }
        public int paymentMethodId { get; set; }
        public string account { get; set; } //Numero tarjeta, correo paypel, etc
    }

}
