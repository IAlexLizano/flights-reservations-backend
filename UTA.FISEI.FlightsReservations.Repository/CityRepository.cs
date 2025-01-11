using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class CityRepository : ICity
    {
        public IEnumerable<City> GetCities()
        {
            using (IDbConnection connection = new SqlConnection(Connection.getConnection()))
            {
                connection.Open();
                try
                {
                    string query = @"
                    SELECT 
                        c.cityId, c.city, c.country
                    FROM Cities c";

                    // Ejecutar la consulta y mapear los resultados a objetos City
                    var cities = connection.Query<City>(query).ToList();

                    return cities;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las ciudades: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
