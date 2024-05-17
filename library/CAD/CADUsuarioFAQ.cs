using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library.CAD
{
    public class CADUsuarioFAQ
    {
        private string constring;

        public CADUsuarioFAQ()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public bool Create(ENUsuarioFAQ en)
        {
            bool created = false;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "INSERT INTO USUARIO_FAQ (id_usuario, id_faq) VALUES (@id_usuario, @id_faq)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id_usuario", en.IdUsuario);
                cmd.Parameters.AddWithValue("@id_faq", en.IdFaq);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                created = rows > 0;
            }
            return created;
        }

        public bool Read(ENUsuarioFAQ en)
        {
            bool found = false;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT id_usuario, id_faq FROM USUARIO_FAQ WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    en.IdUsuario = reader["id_usuario"].ToString();
                    en.IdFaq = (int)reader["id_faq"];
                    found = true;
                }
            }
            return found;
        }

        public bool Update(ENUsuarioFAQ en)
        {
            bool updated = false;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "UPDATE USUARIO_FAQ SET id_usuario = @id_usuario, id_faq = @id_faq WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                cmd.Parameters.AddWithValue("@id_usuario", en.IdUsuario);
                cmd.Parameters.AddWithValue("@id_faq", en.IdFaq);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                updated = rows > 0;
            }
            return updated;
        }

        public bool Delete(ENUsuarioFAQ en)
        {
            bool deleted = false;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "DELETE FROM USUARIO_FAQ WHERE id = @id";
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
