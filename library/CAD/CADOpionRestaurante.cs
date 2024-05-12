using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data.SqlClient;

namespace library
{
    public class CADOpinionRestaurante
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public CADOpinionRestaurante()
        {
            // Constructor
        }

        public bool Create(ENOpinionRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO OpinionRestaurante (cod_restaurante, id_opinion) VALUES (@CodRestaurante, @IdOpinion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CodRestaurante", en.cod_restaurante);
                    command.Parameters.AddWithValue("@IdOpinion", en.id_opion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la opinión del restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Update(ENOpinionRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE OpinionRestaurante SET id_opinion = @IdOpinion WHERE cod_restaurante = @CodRestaurante";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdOpinion", en.id_opion);
                    command.Parameters.AddWithValue("@CodRestaurante", en.cod_restaurante);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la opinión del restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENOpinionRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM OpinionRestaurante WHERE cod_restaurante = @CodRestaurante";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CodRestaurante", en.cod_restaurante);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la opinión del restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Read(ENOpinionRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_opinion FROM OpinionRestaurante WHERE cod_restaurante = @CodRestaurante";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CodRestaurante", en.cod_restaurante);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.id_opion = Convert.ToInt32(reader["id_opinion"]);
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
                Console.WriteLine("Error al leer la opinión del restaurante: " + ex.Message);
                return false;
            }
        }
    }
}

