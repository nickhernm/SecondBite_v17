using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace library
{
    public class CADOpinionPlato
    {
        private string connectionString;

        public CADOpinionPlato()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
                        en.IdOpinion = Convert.ToInt32(reader["id_o"]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ENOpinion> ObtenerOpinionesPlato(int platoId)
        {
            List<ENOpinion> opiniones = new List<ENOpinion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT op.* 
                         FROM OPINION op
                         INNER JOIN OPINION_PLATO op_pl ON op.id = op_pl.id_o
                         WHERE op_pl.id_p = @PlatoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ENOpinion opinion = new ENOpinion();
                    opinion.Id = Convert.ToInt32(reader["id"]);
                    opinion.Descripcion = reader["descripcion"].ToString();
                    opinion.Valoracion = Convert.ToSingle(reader["valoracion"]);
                    opinion.UsuarioCorreo = reader["usuario"].ToString();
                    opiniones.Add(opinion);
                }
            }

            return opiniones;
        }
    }
}
