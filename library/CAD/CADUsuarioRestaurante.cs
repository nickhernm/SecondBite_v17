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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace library
{
    public class CADUsuarioRestaurante
    {
        private string connectionString;

        public CADUsuarioRestaurante()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            
        }

        public bool Create(ENUsuarioRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario, id_metodo_pago) VALUES (@correo, @nombre, @telefono, @tipo_usuario, @id_metodo_pago)";
                    string query = "INSERT INTO USUARIO (correo, nombre, telefono, contrasena, tipo_usuario) VALUES (@correo, @nombre, @telefono, @contrasena, @tipo_usuario)";
                    //string query = "SELECT * from Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);
                        command.Parameters.AddWithValue("@nombre", en.Nombre);
                        command.Parameters.AddWithValue("@telefono", en.Telefono);
                        command.Parameters.AddWithValue("@contrasena", en.Contrasena);
                        command.Parameters.AddWithValue("@tipo_usuario", en.Tipo_usuario);
                        //command.Parameters.AddWithValue("@id_metodo_pago", en.Telefono);
                        System.Diagnostics.Debug.WriteLine("en.Correo:  " + en.Correo);
                        System.Diagnostics.Debug.WriteLine("en.Tipo_usuario:  " + en.Tipo_usuario);
                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("User created successfully.");
                            return true;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No rows affected. Product creation failed.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating User. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Delete(ENUsuarioRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM USUARIO WHERE correo = @correo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);

                        //System.Diagnostics.Debug.WriteLine(command.ExecuteReader());
                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("User deleted successfully.");
                            return true;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No rows affected. User delete failed.");
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al eliminar el usuario. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Update(ENUsuarioRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE USUARIO SET correo = @correo, nombre = @nombre, telefono = @telefono, tipo_usuario = @tipo_usuario, id_metodo_pago = @id_metodo_pago, contrasena = @contrasena, WHERE correo = @correo";
                    //UPDATE Customers SET ContactName = 'Alfred Schmidt', City = 'Frankfurt' WHERE CustomerID = 1;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);
                        command.Parameters.AddWithValue("@nombre", en.Nombre);
                        command.Parameters.AddWithValue("@telefono", en.Telefono);
                        command.Parameters.AddWithValue("@tipo_usuario", en.Tipo_usuario);
                        command.Parameters.AddWithValue("@id_metodo_pago", en.Metodo_pago);
                        command.Parameters.AddWithValue("@contrasena", en.Contrasena);

                        //System.Diagnostics.Debug.WriteLine(command.ExecuteReader());
                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("User updated successfully.");
                            return true;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No rows affected. User update failed.");
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al actualizar el usuario. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Read(ENUsuarioRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT TOP 1 * FROM prueba WHERE correo = @correo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Correo = reader["correo"].ToString();
                                en.Nombre = reader["nombre"].ToString();
                                en.Telefono = reader["telefono"].ToString();
                                en.Tipo_usuario = ("1" == reader["tipo_usuario"].ToString());
                                en.Metodo_pago = reader["correo"].ToString();
                                en.Contrasena = reader["contrasena"].ToString();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al leer el usuario. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool CheckUser(ENUsuarioRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TOP 1 * FROM USUARIO WHERE correo = @correo AND contrasena = @contrasena";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);
                        command.Parameters.AddWithValue("@contrasena", en.Contrasena);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Nombre = reader["nombre"].ToString();
                                en.Telefono = reader["telefono"].ToString();
                                en.Tipo_usuario = ("1" == reader["tipo_usuario"].ToString());
                                en.Metodo_pago = reader["correo"].ToString();
                                return true;
                            }
                            else
                            {
                                return false; // Credenciales incorrectas
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error al leer el usuario. Error: {0}", ex.Message);
                return false;
            }
        }

        public string ObtenerCorreoUsuario(string nombreUsuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT correo FROM USUARIO WHERE nombre = @nombreUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        object result = command.ExecuteScalar();
                        return result != null ? result.ToString() : string.Empty;
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error al obtener el correo del usuario. Error: {0}", ex.Message);
                return string.Empty;
            }
        }
    }
}