using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;
using Dapper;
using System.Linq;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class AirlineRepository : IAirline
    {
        public string addAirline(CreateAirlineDto airline)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        INSERT INTO Airlines (airline, code)
                        VALUES (@AirlineName, @Code);
                    ";

                    connection.Execute(query, new { AirlineName = airline.airline, Code = airline.code });
                    return "Aerolínea agregada exitosamente.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar la aerolínea: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Método para obtener todas las aerolíneas
        public IEnumerable<Airline> GetAirlines()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = "SELECT airlineId, airline, code FROM Airlines";

                    var airlines = connection.Query<Airline>(query).ToList();
                    return airlines;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las aerolíneas: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Método para editar una aerolínea
        public string updateAirline(string id, UpdateAirlineDto airline)
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                        UPDATE Airlines
                        SET airline = @AirlineName, code = @Code
                        WHERE airlineId = @AirlineId;
                    ";

                    int rowsAffected = connection.Execute(query, new { AirlineName = airline.airline, Code = airline.code, AirlineId = id });

                    if (rowsAffected > 0)
                    {
                        return "Aerolínea actualizada exitosamente.";
                    }
                    else
                    {
                        return "No se encontró la aerolínea especificada.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la aerolínea: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
