using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    // Clase CADPlato
    public class CADPlato
    {
        private string connectionString;

        public CADPlato()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public bool Create(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO PLATO (id, nombre, alergenos, puntuacion) VALUES (@PlatoId, @Nombre, @Alergenos, @Puntuacion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PlatoId", en.Id);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Alergenos", en.Alergenos);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al crear el plato: " + ex.Message);
                return false;
            }
        }

        public List<ENPlato> ObtenerPlatosDestacados(int codigoRestaurante)
        {
            List<ENPlato> platos = new List<ENPlato>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT p.* FROM PLATO p INNER JOIN MENU m ON p.id = m.plato WHERE m.restaurante = @RestauranteId ORDER BY p.puntuacion DESC LIMIT 10";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RestauranteId", codigoRestaurante);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ENPlato plato = new ENPlato();
                        plato.Id = Convert.ToInt32(reader["id"]);
                        plato.Nombre = reader["nombre"].ToString();
                        plato.Alergenos = reader["alergenos"].ToString();
                        plato.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        platos.Add(plato);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los platos destacados: " + ex.Message);
            }
            return platos;
        }
    

    public bool Read(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PLATO WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Nombre = reader["nombre"].ToString();
                        en.Alergenos = reader["alergenos"].ToString();
                        en.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al leer el plato: " + ex.Message);
                return false;
            }
        }

        public bool Update(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE PLATO SET nombre = @Nombre, alergenos = @Alergenos, puntuacion = @Puntuacion WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", en.Nombre);
                    command.Parameters.AddWithValue("@Alergenos", en.Alergenos);
                    command.Parameters.AddWithValue("@Puntuacion", en.Puntuacion);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar el plato: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ENPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM PLATO WHERE id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", en.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al eliminar el plato: " + ex.Message);
                return false;
            }
        }

        public List<ENPlato> ReadAll()
        {
            List<ENPlato> platos = new List<ENPlato>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PLATO";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ENPlato plato = new ENPlato();
                        plato.Id = Convert.ToInt32(reader["id"]);
                        plato.Nombre = reader["nombre"].ToString();
                        plato.Alergenos = reader["alergenos"].ToString();
                        plato.Puntuacion = Convert.ToSingle(reader["puntuacion"]); platos.Add(plato);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los platos: " + ex.Message);
            }

            return platos;
        }

        public List<ENPlato> ObtenerPlatosRestaurante(int restauranteId)
        {
            List<ENPlato> platos = new List<ENPlato>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT p.* FROM PLATO p INNER JOIN MENU m ON p.id = m.plato WHERE m.restaurante = @RestauranteId";
                    SqlCommand command = new SqlCommand(query, connection); command.Parameters.AddWithValue("@RestauranteId", restauranteId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ENPlato plato = new ENPlato();
                        plato.Id = Convert.ToInt32(reader["id"]);
                        plato.Nombre = reader["nombre"].ToString();
                        plato.Alergenos = reader["alergenos"].ToString();
                        plato.Puntuacion = Convert.ToSingle(reader["puntuacion"]);
                        platos.Add(plato);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los platos del restaurante: " + ex.Message);
            }
            return platos;
        }
    }
}
