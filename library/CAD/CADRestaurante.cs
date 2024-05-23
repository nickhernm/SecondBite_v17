using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace library
{
    public class CADRestaurante
    {
        private string connectionString;

        public CADRestaurante()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public List<ENRestaurante> ObtenerRestaurantes()
        {
            List<ENRestaurante> restaurantes = new List<ENRestaurante>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM RESTAURANTE";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ENRestaurante restaurante = new ENRestaurante();
                        restaurante.Cod = Convert.ToInt32(reader["cod"]);
                        restaurante.Nombre = reader["nombre"].ToString();
                        restaurante.Localidad = reader["localidad"].ToString();
                        restaurante.Tipo = reader["tipo"].ToString();
                        restaurante.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        restaurantes.Add(restaurante);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los restaurantes: " + ex.Message);
            }
            return restaurantes;
        }

        public bool Create(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO RESTAURANTE (nombre, localidad, tipo, puntuacion) VALUES (@Nombre, @Localidad, @Tipo, @Puntuacion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Localidad", en.Localidad);
                    command.Parameters.AddWithValue("@Tipo", en.Tipo);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al crear el restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Read(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM RESTAURANTE WHERE cod = @Cod";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cod", en.Cod);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Nombre = reader["nombre"].ToString();
                        en.Localidad = reader["localidad"].ToString();
                        en.Tipo = reader["tipo"].ToString();
                        en.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al leer el restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Update(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE RESTAURANTE SET nombre = @Nombre, localidad = @Localidad, tipo = @Tipo, puntuacion = @Puntuacion WHERE cod = @Cod";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cod", en.Cod);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Localidad", en.Localidad);
                    command.Parameters.AddWithValue("@Tipo", en.Tipo);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar el restaurante: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM RESTAURANTE WHERE cod = @Cod";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cod", en.Cod);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al eliminar el restaurante: " + ex.Message);
                return false;
            }
        }

        public List<ENRestaurante> ObtenerRestaurantes(string busqueda, string comunidad, string tipo, string puntuacion)
        {
            List<ENRestaurante> restaurantes = new List<ENRestaurante>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM RESTAURANTE WHERE 1 = 1";

                    if (!string.IsNullOrEmpty(busqueda))
                    {
                        query += " AND nombre LIKE @Busqueda";
                    }

                    if (!string.IsNullOrEmpty(comunidad))
                    {
                        query += " AND comunidad = @Comunidad";
                    }

                    if (!string.IsNullOrEmpty(tipo))
                    {
                        query += " AND tipo = @Tipo";
                    }

                    if (!string.IsNullOrEmpty(puntuacion))
                    {
                        query += " AND puntuacion >= @Puntuacion";
                    }

                    SqlCommand command = new SqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(busqueda))
                    {
                        command.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");
                    }

                    if (!string.IsNullOrEmpty(comunidad))
                    {
                        command.Parameters.AddWithValue("@Comunidad", comunidad);
                    }

                    if (!string.IsNullOrEmpty(tipo))
                    {
                        command.Parameters.AddWithValue("@Tipo", tipo);
                    }

                    if (!string.IsNullOrEmpty(puntuacion))
                    {
                        command.Parameters.AddWithValue("@Puntuacion", puntuacion);
                    }

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ENRestaurante restaurante = new ENRestaurante();
                        restaurante.Cod = Convert.ToInt32(reader["cod"]);
                        restaurante.Nombre = reader["nombre"].ToString();
                        restaurante.Localidad = reader["localidad"].ToString();
                        restaurante.Tipo = reader["tipo"].ToString();
                        restaurante.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        restaurantes.Add(restaurante);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los restaurantes: " + ex.Message);
            }

            return restaurantes;
        }

        public List<string> ObtenerTipos()
        {
            List<string> tipos = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT tipo FROM RESTAURANTE";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tipos.Add(reader["tipo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los tipos de restaurantes: " + ex.Message);
            }

            return tipos;
        }

        public List<string> ObtenerComunidades()
        {
            List<string> comunidades = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT comunidad FROM RESTAURANTE";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comunidades.Add(reader["comunidad"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener las comunidades de restaurantes: " + ex.Message);
            }

            return comunidades;
        }
    }
}
