using System;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADMenu
    {
        private string connectionString;

        public CADMenu()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

        }

        public bool Create(ENMenu menu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO MENU (restaurante, plato) VALUES (@RestauranteId, @PlatoId)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RestauranteId", menu.RestauranteId);
                    command.Parameters.AddWithValue("@PlatoId", menu.PlatoId);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el menú: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENMenu menu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM MENU WHERE restaurante = @RestauranteId AND plato = @PlatoId";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RestauranteId", menu.RestauranteId);
                    command.Parameters.AddWithValue("@PlatoId", menu.PlatoId);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el menú: " + ex.Message);
                return false;
            }
        }

        public bool Read(ENMenu menu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM MENU WHERE restaurante = @RestauranteId AND plato = @PlatoId";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RestauranteId", menu.RestauranteId);
                    command.Parameters.AddWithValue("@PlatoId", menu.PlatoId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el menú: " + ex.Message);
                return false;
            }
        }
    }
}
