using System;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADRestaurante
    {
        private string connectionString;

        public CADRestaurante()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool Create(ENRestaurante restaurante)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO RESTAURANTE (cod, nombre, localidad, tipo, puntuacion) VALUES (@Cod, @Nombre, @Localidad, @Tipo, @Puntuacion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cod", restaurante.Cod);
                command.Parameters.AddWithValue("@Nombre", restaurante.Nombre);
                command.Parameters.AddWithValue("@Localidad", restaurante.Localidad);
                command.Parameters.AddWithValue("@Tipo", restaurante.Tipo);
                command.Parameters.AddWithValue("@Puntuacion", restaurante.Puntuacion);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al crear restaurante: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Read(ENRestaurante restaurante)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM RESTAURANTE WHERE cod = @Cod";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cod", restaurante.Cod);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Asignar los valores leídos al objeto restaurante
                        restaurante.Nombre = reader["nombre"].ToString();
                        restaurante.Localidad = reader["localidad"].ToString();
                        restaurante.Tipo = reader["tipo"].ToString();
                        restaurante.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        return true;
                    }
                    return false; // No se encontró el restaurante
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al leer restaurante: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Update(ENRestaurante restaurante)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE RESTAURANTE SET nombre = @Nombre, localidad = @Localidad, tipo = @Tipo, puntuacion = @Puntuacion WHERE cod = @Cod";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cod", restaurante.Cod);
                command.Parameters.AddWithValue("@Nombre", restaurante.Nombre);
                command.Parameters.AddWithValue("@Localidad", restaurante.Localidad);
                command.Parameters.AddWithValue("@Tipo", restaurante.Tipo);
                command.Parameters.AddWithValue("@Puntuacion", restaurante.Puntuacion);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Si se actualizó algún registro
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al actualizar restaurante: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(ENRestaurante restaurante)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM RESTAURANTE WHERE cod = @Cod";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cod", restaurante.Cod);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Si se eliminó algún registro
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al eliminar restaurante: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
