using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    // Clase CADPlato
    public class CADPlato
    {
        private string connectionString;

        public CADPlato()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        public bool Create(ENPlato en)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO PLATO (nombre, alergenos, puntuacion) VALUES (@Nombre, @Alergenos, @Puntuacion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Alergenos", en.Alergenos);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al crear el plato: " + ex.Message);
                return false;
            }
        }

        public bool Read(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PLATO WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Nombre = reader["nombre"].ToString();
                        en.Alergenos = reader["alergenos"].ToString();
                        en.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al leer el plato: " + ex.Message);
                return false;
            }
        }

        public bool Update(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE PLATO SET nombre = @Nombre, alergenos = @Alergenos, puntuacion = @Puntuacion WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Alergenos", en.Alergenos);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar el plato: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM PLATO WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al eliminar el plato: " + ex.Message);
                return false;
            }
        }
    }
}
