using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class ReservationFacade : IDisposable
    {
        private readonly IReservation _reservationRepository;

        public ReservationFacade()
        {
            _reservationRepository = new ReservationRepository();
        }

        public IEnumerable<ReservationResponse> GetAllReservations()
        {
            return _reservationRepository.GetReservations();
        }

        public Reservation GetReservationById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("El ID de la reservación no puede estar vacío.", nameof(id));
            }

            return _reservationRepository.GetReservationById(id);
        }

        public IEnumerable<Reservation> GetReservationsByClient(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException("El ID del cliente no puede estar vacío.", nameof(clientId));
            }

            return _reservationRepository.GetReservationsByClient(clientId);
        }

        public Reservation CreateReservation(CreateReservationDto reservationDto)
        {
            if (reservationDto == null)
            {
                throw new ArgumentNullException(nameof(reservationDto), "Los datos de la reservación son obligatorios.");
            }

            return _reservationRepository.createReservation(reservationDto);
        }

        public Reservation UpdateReservation(string id, UpdateReservationDto reservationDto)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("El ID de la reservación no puede estar vacío.", nameof(id));
            }

            if (reservationDto == null)
            {
                throw new ArgumentNullException(nameof(reservationDto), "Los datos de la reservación son obligatorios.");
            }

            return _reservationRepository.updateReservation(id, reservationDto);
        }

        public string CancelReservation(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("El ID de la reservación no puede estar vacío.", nameof(id));
            }

            return _reservationRepository.cancelReservation(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
