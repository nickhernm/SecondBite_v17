using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADOpinionPlato
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public CADOpinionPlato()
        {
            // Constructor
        }

        public bool Create(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO OPINION_PLATO (id_p, id_o) VALUES (@IdPlato, @IdOpinion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);
                    command.Parameters.AddWithValue("@IdOpinion", en.IdOpinion);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public bool Update(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE OPINION_PLATO SET id_o = @IdOpinion WHERE id_p = @IdPlato";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);
                    command.Parameters.AddWithValue("@IdOpinion", en.IdOpinion);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public bool Delete(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OPINION_PLATO WHERE id_p = @IdPlato";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public bool Read(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OPINION_PLATO WHERE id_p = @IdPlato";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Asignar valores leídos a las propiedades del objeto ENOpinionPlato
                        en.IdOpinion = Convert.ToInt32(reader["id_o"]);
                        return true;
                    }
                    else
                    {
                        return false; // No se encontró ninguna opinión para el plato
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }
    }
}
