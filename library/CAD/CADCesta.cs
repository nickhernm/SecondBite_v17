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
	public class CADCesta
	{
        private string connectionString;
        public CADCesta()
    	{
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

    	public bool Create(ENCesta en)
    	{
            bool created = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CESTA (id, num_pedido) VALUES (@id, @num_pedido)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                if (en.NumPedido.HasValue)
                {
                    cmd.Parameters.AddWithValue("@num_pedido", en.NumPedido.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@num_pedido", DBNull.Value);
                }
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                created = rows > 0;
            }
            return created;
        }

        public bool Update(ENCesta en)
    	{
            bool updated = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE CESTA SET num_pedido = @num_pedido WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                if (en.NumPedido.HasValue)
                {
                    cmd.Parameters.AddWithValue("@num_pedido", en.NumPedido.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@num_pedido", DBNull.Value);
                }
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                updated = rows > 0;
            }
            return updated;
        }

        public bool Read(ENCesta en)
    	{
            bool found = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id, num_pedido FROM CESTA WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    en.Id = (int)reader["id"];
                    en.NumPedido = reader["num_pedido"] != DBNull.Value ? (int?)reader["num_pedido"] : null;
                    found = true;
                }
            }
            return found;
        }

        public bool Delete(ENCesta en)
    	{
            bool deleted = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CESTA WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", en.Id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                deleted = rows > 0;
            }
            return deleted;
        }

        /*public List<ENLinea> GetLines(ENCesta en)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LINPED where CESTA.num_pedido = LINPED.num_pedido";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    ENLinea linea = new ENLinea();
                    linea.Linea = Convert.ToInt32(reader["linea"]);
                    linea.NumPed = reader["num_pedido"].ToString();
                    linea.Importe = reader["Importe"].ToString();
                    linea.Cantidad = reader["Cantidad"].ToString();
                    linea.Plato = Convert.ToSingle(reader["Plato"]);
                    linea.Add(linea);
                }
            }
                
        }*/

	}

}
