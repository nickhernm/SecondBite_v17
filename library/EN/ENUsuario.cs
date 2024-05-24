using System;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class ENUsuario
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public bool TipoUsuario { get; set; }

        public bool Authenticate()
        {
            bool isAuthenticated = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM USUARIO WHERE correo = @correo AND contrasena = @contrasena";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@correo", Correo);
                    command.Parameters.AddWithValue("@contrasena", Contrasena);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isAuthenticated = (count > 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar el usuario: " + ex.Message);
            }

            return isAuthenticated;
        }

        public void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT nombre, telefono, tipo_usuario FROM USUARIO WHERE correo = @correo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@correo", Correo);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Nombre = reader["nombre"].ToString();
                        Telefono = reader["telefono"].ToString();
                        TipoUsuario = Convert.ToBoolean(reader["tipo_usuario"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los datos del usuario: " + ex.Message);
            }
        }
    }
}