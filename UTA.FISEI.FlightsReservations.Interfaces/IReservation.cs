using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IReservation
    {
        IEnumerable<ReservationResponse> GetReservations();
        IEnumerable<Reservation> GetReservationsByClient(string clientId);
        Reservation GetReservationById(string id);
        Reservation createReservation(CreateReservationDto reservation);
        Reservation updateReservation(string id, UpdateReservationDto reservation);
        string cancelReservation(string id);
    }
}
