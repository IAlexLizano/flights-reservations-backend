using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class ClientRepository: IClient
    {
        public Client getClientById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = @"
                SELECT 
                    c.clientId, c.dni, c.firstName, c.lastName, c.birthDate, c.registrationDate,
                    u.userId, u.email, u.roleId
                FROM Clients c
                INNER JOIN Users u ON c.userId = u.userId
                WHERE c.clientId = @Id AND u.isActive = 1";

                var clientR = connection.Query<Client, User, Client>(
                    query,
                    (client, user) =>
                    {
                        client.userId = user; // Asignar el usuario al cliente
                        return client;
                    },
                    new { Id = id },
                    splitOn: "userId"
                ).FirstOrDefault();

                connection.Close();
                return clientR;
            }
        }


        public IEnumerable<Client> GetClients()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                string query = @"
            SELECT 
                c.clientId, c.dni, c.firstName, c.lastName, c.birthDate, c.registrationDate,
                u.userId, u.email, u.roleId
            FROM Clients c
            INNER JOIN Users u ON c.userId = u.userId
            WHERE u.isActive = 1";

                var clients = connection.Query<Client, User, Client>(
                    query,
                    (client, user) =>
                    {
                        client.userId = user;
                        return client;
                    },
                    splitOn: "userId"
                ).ToList();

                connection.Close();
                return clients;
            }
        }

        public Client createClient(CreateClientDto dto)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertUserQuery = @"
                    INSERT INTO Users (email, password, roleId) 
                    OUTPUT INSERTED.userId 
                    VALUES (@Email, @Password, 2)
                ";

                        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.password); // Cifrar contraseña
                        var userId = connection.ExecuteScalar<int>(insertUserQuery, new
                        {
                            Email = dto.email,
                            Password = hashedPassword
                        }, transaction);

                        string insertClientQuery = @"
                    INSERT INTO Clients (dni, firstName, lastName, birthDate, userId)
                    OUTPUT INSERTED.clientId
                    VALUES (@Dni, @FirstName, @LastName, @BirthDate, @UserId)
                ";

                        var clientId = connection.ExecuteScalar<int>(insertClientQuery, new
                        {
                            Dni = dto.dni,
                            FirstName = dto.firstName,
                            LastName = dto.lastName,
                            BirthDate = dto.birthDate,
                            UserId = userId
                        }, transaction);

                        transaction.Commit();

                        return getClientById(clientId);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new Exception("Error al registrar el cliente");
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
