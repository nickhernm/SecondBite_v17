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
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public bool Create(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO RESTAURANTE (nombre, localidad, tipo, puntuacion) VALUES (@Nombre, @Localidad, @Tipo, @Puntuacion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Localidad", en.Localidad);
                    command.Parameters.AddWithValue("@Tipo", en.Tipo);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al crear el restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Read(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM RESTAURANTE WHERE cod = @Cod";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cod", en.Cod);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Nombre = reader["nombre"].ToString();
                        en.Localidad = reader["localidad"].ToString();
                        en.Tipo = reader["tipo"].ToString();
                        en.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al leer el restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Update(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE RESTAURANTE SET nombre = @Nombre, localidad = @Localidad, tipo = @Tipo, puntuacion = @Puntuacion WHERE cod = @Cod";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cod", en.Cod);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Localidad", en.Localidad);
                    command.Parameters.AddWithValue("@Tipo", en.Tipo);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar el restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM RESTAURANTE WHERE cod = @Cod";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cod", en.Cod);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al eliminar el restaurante: " + ex.Message);
                return false;
            }
        }
    }
}
