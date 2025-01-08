using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class ReservationService : IReservationService
    {
        public IEnumerable<ReservationResponse> GetAllReservations()
        {
            using (var facade = new ReservationFacade())
            {
                try
                {
                    return facade.GetAllReservations();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ocurrió un error al obtener las reservaciones.", ex);
                }
            }
        }

        public Reservation GetReservationById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("El ID de la reservación no puede estar vacío.", nameof(id));
            }

            using (var facade = new ReservationFacade())
            {
                try
                {
                    return facade.GetReservationById(id);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ocurrió un error al obtener la reservación.", ex);
                }
            }
        }

        public IEnumerable<Reservation> GetReservationsByClient(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException("El ID del cliente no puede estar vacío.", nameof(clientId));
            }

            using (var facade = new ReservationFacade())
            {
                try
                {
                    return facade.GetReservationsByClient(clientId);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ocurrió un error al obtener las reservaciones del cliente.", ex);
                }
            }
        }

        public Reservation CreateReservation(CreateReservationDto reservationDto)
        {
            if (reservationDto == null)
            {
                throw new ArgumentNullException(nameof(reservationDto), "Los datos de la reservación son obligatorios.");
            }

            using (var facade = new ReservationFacade())
            {
                try
                {
                    return facade.CreateReservation(reservationDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new ApplicationException("Ocurrió un error al crear la reservación.", ex);
                }
            }
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

            using (var facade = new ReservationFacade())
            {
                try
                {
                    return facade.UpdateReservation(id, reservationDto);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ocurrió un error al actualizar la reservación.", ex);
                }
            }
        }

        public string CancelReservation(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("El ID de la reservación no puede estar vacío.", nameof(id));
            }

            using (var facade = new ReservationFacade())
            {
                try
                {
                    return facade.CancelReservation(id);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ocurrió un error al cancelar la reservación.", ex);
                }
            }
        }
    }
}
