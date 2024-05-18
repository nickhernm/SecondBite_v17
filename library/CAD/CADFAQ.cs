using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace library
{
    public class CADFAQ
    {
        private string connectionString;

        public CADFAQ()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public bool Create(ENFAQ en)
        {
            
            bool created = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO FAQ (pregunta, respuesta) VALUES (@pregunta, @respuesta)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pregunta", en.Pregunta);
                cmd.Parameters.AddWithValue("@respuesta", en.Respuesta);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                created = rows > 0;
            }
            return created;
        }

        public bool Read(ENFAQ en)
        {
            bool found = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT pregunta, respuesta FROM FAQ WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    en.Pregunta = reader["pregunta"].ToString();
                    en.Respuesta = reader["respuesta"].ToString();
                    found = true;
                }
            }
            return found;
        }

        public bool Update(ENFAQ en)
        {
            bool updated = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE FAQ SET pregunta = @pregunta, respuesta = @respuesta WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                cmd.Parameters.AddWithValue("@pregunta", en.Pregunta);
                cmd.Parameters.AddWithValue("@respuesta", en.Respuesta);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                updated = rows > 0;
            }
            return updated;
        }

        public bool Delete(ENFAQ en)
        {
            bool deleted = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM FAQ WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                deleted = rows > 0;
            }
            return deleted;
        }
    }
}
