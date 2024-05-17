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
    public class CADDireccion
    {
        private string connectionString;
        public CADDireccion()
        {
            
        }

        public bool Create(ENDireccion direccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO DIRECCION (nombre_calle, calle_num, cod_p, ciudad, comunidad, restaurante, cliente) 
                                 VALUES (@NombreCalle, @CalleNumero, @CodigoPostal, @Ciudad, @Comunidad, @RestauranteId, @ClienteCorreo)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreCalle", direccion.NombreCalle);
                command.Parameters.AddWithValue("@CalleNumero", direccion.CalleNumero);
                command.Parameters.AddWithValue("@CodigoPostal", direccion.CodigoPostal);
                command.Parameters.AddWithValue("@Ciudad", direccion.Ciudad);
                command.Parameters.AddWithValue("@Comunidad", direccion.Comunidad);
                command.Parameters.AddWithValue("@RestauranteId", direccion.RestauranteId);
                command.Parameters.AddWithValue("@ClienteCorreo", direccion.ClienteCorreo);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para actualizar una dirección
        public bool Update(ENDireccion direccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE DIRECCION 
                                 SET nombre_calle = @NombreCalle, calle_num = @CalleNumero, 
                                     cod_p = @CodigoPostal, ciudad = @Ciudad, comunidad = @Comunidad,
                                     restaurante = @RestauranteId, cliente = @ClienteCorreo 
                                 WHERE nombre_calle = @NombreCalle AND calle_num = @CalleNumero";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreCalle", direccion.NombreCalle);
                command.Parameters.AddWithValue("@CalleNumero", direccion.CalleNumero);
                command.Parameters.AddWithValue("@CodigoPostal", direccion.CodigoPostal);
                command.Parameters.AddWithValue("@Ciudad", direccion.Ciudad);
                command.Parameters.AddWithValue("@Comunidad", direccion.Comunidad);
                command.Parameters.AddWithValue("@RestauranteId", direccion.RestauranteId);
                command.Parameters.AddWithValue("@ClienteCorreo", direccion.ClienteCorreo);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para eliminar una dirección
        public bool Delete(ENDireccion direccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM DIRECCION 
                                 WHERE nombre_calle = @NombreCalle AND calle_num = @CalleNumero";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreCalle", direccion.NombreCalle);
                command.Parameters.AddWithValue("@CalleNumero", direccion.CalleNumero);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para leer una dirección
        public bool Read(ENDireccion direccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM DIRECCION 
                         WHERE nombre_calle = @NombreCalle AND calle_num = @CalleNumero";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreCalle", direccion.NombreCalle);
                command.Parameters.AddWithValue("@CalleNumero", direccion.CalleNumero);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

    }
}