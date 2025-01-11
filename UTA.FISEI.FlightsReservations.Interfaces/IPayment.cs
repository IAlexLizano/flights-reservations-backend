using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IPayment
    {
        string createPayment(int reservationId, CreateReservationDto dto);
    }
}
