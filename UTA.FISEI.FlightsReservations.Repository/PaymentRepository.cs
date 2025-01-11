using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class PaymentRepository : IPayment
    {
        public string createPayment(int reservationId, CreateReservationDto dto)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string reservationQuery = "SELECT COUNT(*) FROM Reservations WHERE reservationId = @ReservationId";
                    int reservationExists = connection.ExecuteScalar<int>(reservationQuery, new { ReservationId = reservationId });

                    if (reservationExists == 0)
                    {
                        throw new Exception("La reserva especificada no existe.");
                    }

                    string paymentQuery = @"
                        INSERT INTO Payments (
                            reservationId, amount, paymentDate, paymentMethodId, account
                        ) 
                        VALUES (
                            @ReservationId, @Amount, GETDATE(), @PaymentMethodId, @Account
                        );
                    ";

                    connection.Execute(paymentQuery, new
                    {
                        ReservationId = reservationId,
                        Amount = dto.amount,
                        PaymentMethodId = dto.paymentMethodId,
                        Account = dto.account
                    });

                    return "Pago realizado correctamente";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al crear el pago: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
