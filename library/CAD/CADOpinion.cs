using System;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADOpinion
    {
        private string connectionString;

        public CADOpinion()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

        }

        public bool Create(ENOpinion en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO OPINION (descripcion, valoracion, usuario) VALUES (@Descripcion, @Valoracion, @UsuarioCorreo)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Descripcion", en.Descripcion);
                    command.Parameters.AddWithValue("@Valoracion", en.Valoracion);
                    command.Parameters.AddWithValue("@UsuarioCorreo", en.UsuarioCorreo);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la opinión: " + ex.Message);
                return false;
            }
        }

        public bool Read(ENOpinion en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM OPINION WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Descripcion = reader["descripcion"].ToString();
                        en.Valoracion = Convert.ToSingle(reader["valoracion"]);
                        en.UsuarioCorreo = reader["usuario"].ToString();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer la opinión: " + ex.Message);
                return false;
            }
        }

        public bool Update(ENOpinion en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE OPINION SET descripcion = @Descripcion, valoracion = @Valoracion, usuario = @UsuarioCorreo WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Descripcion", en.Descripcion);
                    command.Parameters.AddWithValue("@Valoracion", en.Valoracion);
                    command.Parameters.AddWithValue("@UsuarioCorreo", en.UsuarioCorreo);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la opinión: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENOpinion en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM OPINION WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la opinión: " + ex.Message);
                return false;
            }
        }
    }
}
