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
    public class CADCliente
    {
        private string connectionString;
        public CADCliente()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public bool EsRestaurante(string username)
        {
            bool esRestaurante = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT tipo_usuario FROM USUARIO WHERE correo = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        esRestaurante = Convert.ToBoolean(result);
                    }
                }
            }

            return esRestaurante;
        }
    }
}