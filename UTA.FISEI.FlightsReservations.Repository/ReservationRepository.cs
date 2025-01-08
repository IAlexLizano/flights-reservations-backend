using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class ReservationRepository : IReservation
    {
        PaymentRepository _paymentRepository;
        FlightRepository _flightRepository;
        public ReservationRepository() {
            _paymentRepository = new PaymentRepository();
            _flightRepository = new FlightRepository();
        }
        public string cancelReservation(string id)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = "UPDATE Reservations SET status = 'Cancelado' WHERE reservationId = @Id";

                int rowsAffected = connection.Execute(query, new { Id = id });

                connection.Close();
                return rowsAffected > 0 ? "Reservación cancelada exitosamente" : "Error al cancelar la reservación";
            }
        }

        public Reservation createReservation(CreateReservationDto reservationDto)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO Reservations (userId, flightId, reservationDate, status, numberOfPassengers) 
                                 VALUES (@UserId, @FlightId, GETDATE(), @Status, @NumberOfPassengers);
                                 SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int reservationId = connection.QuerySingle<int>(query, new
                        {
                            UserId = reservationDto.userId,
                            FlightId = reservationDto.flightId,
                            Status = "Reservado",
                            NumberOfPassengers = reservationDto.numberOfPassengers
                        }, transaction);

                        transaction.Commit();

                        _paymentRepository.createPayment(reservationId, reservationDto);

                        return GetReservationById(reservationId.ToString());
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("Error al crear la reservación");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        public Reservation GetReservationById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = @"SELECT 
                                    r.reservationId, r.reservationDate, r.status, r.numberOfPassengers,
                                    u.userId, u.email, u.roleId,
                                    f.flightId, f.departureDate, f.arrivalDate, f.type, f.price, f.availableSeats
                                FROM Reservations r
                                INNER JOIN Users u ON r.userId = u.userId
                                INNER JOIN Flights f ON r.flightId = f.flightId
                                WHERE r.reservationId = @Id";

                var reservation = connection.Query<Reservation, User, Flight, Reservation>(
                    query,
                    (res, user, flight) =>
                    {
                        res.userId = user;
                        res.flightId = flight;
                        return res;
                    },
                    new { Id = id },
                    splitOn: "userId,flightId"
                ).FirstOrDefault();

                connection.Close();
                return reservation;
            }
        }

        public IEnumerable<ReservationResponse> GetReservations()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = @"SELECT 
                                    r.reservationId, r.reservationDate, r.status, r.numberOfPassengers,
                                    u.userId, u.email,
                                    c.clientId, c.firstName, c.lastName, c.dni,
                                    f.flightId, f.departureDate, f.arrivalDate, f.type, f.price, f.availableSeats,
                                    p.paymentId, p.amount, p.account,
                                    m.paymentMethodId, m.paymentMethod
                                FROM Reservations r
                                INNER JOIN Users u ON r.userId = u.userId
                                INNER JOIN Clients c ON u.userId = c.userId
                                INNER JOIN Flights f ON r.flightId = f.flightId
                                INNER JOIN Payments p ON r.reservationId = p.reservationId
                                INNER JOIN PaymentMethods m ON p.paymentMethodId = m.paymentMethodId
                                ORDER BY r.reservationDate";

                var reservations = connection.Query<ReservationResponse, User, Client, Flight, Payment, PaymentMethod, ReservationResponse>(
                    query,
                    (res, user, client, flight, payment, method) =>
                    {
                        res.clientId = client;
                        res.clientId.userId = user;
                        res.flightId = _flightRepository.GetFlightById(flight.flightId+"");
                        res.paymentId = payment;
                        res.paymentId.paymentMethodId = method;
                        return res;
                    },
                    splitOn: "userId, clientId, flightId, paymentId, paymentMethodId"
                ).ToList();

                connection.Close();
                return reservations;
            }
        }

        public IEnumerable<Reservation> GetReservationsByClient(string clientId)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = @"SELECT 
                                    r.reservationId, r.reservationDate, r.status, r.numberOfPassengers,
                                    u.userId, u.email, u.roleId,
                                    f.flightId, f.departureDate, f.arrivalDate, f.type, f.price, f.availableSeats
                                FROM Reservations r
                                INNER JOIN Users u ON r.userId = u.userId
                                INNER JOIN Flights f ON r.flightId = f.flightId
                                WHERE r.userId = @ClientId
                                ORDER BY f.departureDate";

                var reservations = connection.Query<Reservation, User, Flight, Reservation>(
                    query,
                    (res, user, flight) =>
                    {
                        res.userId = user;
                        res.flightId = _flightRepository.GetFlightById(flight.flightId + "");
                        return res;
                    },
                    new { ClientId = clientId },
                    splitOn: "userId,flightId"
                ).ToList();

                connection.Close();
                return reservations;
            }
        }

        public Reservation updateReservation(string id, UpdateReservationDto reservationDto)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"UPDATE Reservations
                                         SET numberOfPassengers = @NumberOfPassengers
                                         WHERE reservationId = @ReservationId";

                        int rowsAffected = connection.Execute(query, new
                        {
                            ReservationId = id,
                            NumberOfPassengers = reservationDto.numberOfPassengers
                        }, transaction);

                        transaction.Commit();

                        return rowsAffected > 0 ? GetReservationById(id) : null;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("Error al actualizar la reservación");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
