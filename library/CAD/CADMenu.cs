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
                    // Abre la conexión
                    connection.Open();

                    // Crea el comando SQL para insertar un nuevo registro en la tabla MENU
                    string query = "INSERT INTO MENU (restaurante, plato) VALUES (@RestauranteId, @PlatoId)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Establece los parámetros del comando
                    command.Parameters.AddWithValue("@RestauranteId", menu.RestauranteId);
                    command.Parameters.AddWithValue("@PlatoId", menu.PlatoId);

                    // Ejecuta el comando
                    int rowsAffected = command.ExecuteNonQuery();

                    // Retorna true si al menos una fila fue afectada
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, podrías registrar el error en un log o lanzar una excepción
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
                    // Abre la conexión
                    connection.Open();

                    // Crea el comando SQL para eliminar un registro de la tabla MENU
                    string query = "DELETE FROM MENU WHERE restaurante = @RestauranteId AND plato = @PlatoId";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Establece los parámetros del comando
                    command.Parameters.AddWithValue("@RestauranteId", menu.RestauranteId);
                    command.Parameters.AddWithValue("@PlatoId", menu.PlatoId);

                    // Ejecuta el comando
                    int rowsAffected = command.ExecuteNonQuery();

                    // Retorna true si al menos una fila fue afectada
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, podrías registrar el error en un log o lanzar una excepción
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
                    // Abre la conexión
                    connection.Open();

                    // Crea el comando SQL para leer un registro de la tabla MENU
                    string query = "SELECT COUNT(*) FROM MENU WHERE restaurante = @RestauranteId AND plato = @PlatoId";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Establece los parámetros del comando
                    command.Parameters.AddWithValue("@RestauranteId", menu.RestauranteId);
                    command.Parameters.AddWithValue("@PlatoId", menu.PlatoId);

                    // Ejecuta el comando y obtiene el resultado
                    int count = (int)command.ExecuteScalar();

                    // Retorna true si se encontró al menos un registro
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, podrías registrar el error en un log o lanzar una excepción
                Console.WriteLine("Error al leer el menú: " + ex.Message);
                return false;
            }
        }
    }
}
