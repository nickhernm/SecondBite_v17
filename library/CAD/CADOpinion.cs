using System;
using System.Data.SqlClient;

namespace library
{
    public class CADOpinion
    {
        private string connectionString;

        public CADOpinion()
        {
            
        }

        public bool Create(ENOpinion en)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO OPINION (id, descripcion, valoracion, usuario) VALUES (@Id, @Descripcion, @Valoracion, @UsuarioCorreo)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", en.Id);
                command.Parameters.AddWithValue("@Descripcion", en.Descripcion);
                command.Parameters.AddWithValue("@Valoracion", en.Valoracion);
                command.Parameters.AddWithValue("@UsuarioCorreo", en.UsuarioCorreo);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Read(ENOpinion en)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OPINION WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", en.Id);

                connection.Open();
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

        public bool Update(ENOpinion en)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE OPINION SET descripcion = @Descripcion, valoracion = @Valoracion, usuario = @UsuarioCorreo WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Descripcion", en.Descripcion);
                command.Parameters.AddWithValue("@Valoracion", en.Valoracion);
                command.Parameters.AddWithValue("@UsuarioCorreo", en.UsuarioCorreo);
                command.Parameters.AddWithValue("@Id", en.Id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Delete(ENOpinion en)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM OPINION WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", en.Id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
