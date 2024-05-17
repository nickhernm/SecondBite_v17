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

namespace library
{
    public class CADUsuarioRestaurante
    {
        private string constring;

        public CADUsuarioRestaurante()
        {

            constring = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            System.Diagnostics.Debug.WriteLine(constring);
        }

        public bool Create(ENUsuarioRestaurante en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    //string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario, id_metodo_pago) VALUES (@correo, @nombre, @telefono, @tipo_usuario, @id_metodo_pago)";
                    string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario) VALUES (@correo, @nombre, @telefono, @tipo_usuario)";
                    //string query = "SELECT * from Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);
                        command.Parameters.AddWithValue("@nombre", en.Nombre);
                        command.Parameters.AddWithValue("@telefono", en.Telefono);
                        command.Parameters.AddWithValue("@tipo_usuario", 1);
                        //command.Parameters.AddWithValue("@id_metodo_pago", en.Telefono);


                        //System.Diagnostics.Debug.WriteLine(command.ExecuteReader());
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
                using (SqlConnection connection = new SqlConnection(constring))
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
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    string query = "UPDATE USUARIO SET correo = @correo, nombre = @nombre, telefono = @telefono, tipo_usuario = @tipo_usuario, id_metodo_pago = @id_metodo_pago WHERE correo = @correo";
                    //UPDATE Customers SET ContactName = 'Alfred Schmidt', City = 'Frankfurt' WHERE CustomerID = 1;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);
                        command.Parameters.AddWithValue("@nombre", en.Nombre);
                        command.Parameters.AddWithValue("@telefono", en.Telefono);
                        command.Parameters.AddWithValue("@tipo_usuario", en.Telefono);
                        command.Parameters.AddWithValue("@id_metodo_pago", en.Telefono);

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
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();

                    string query = "SELECT TOP 1 * FROM USUARIO WHERE correo = @correo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", en.Correo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Nif = reader["nif"].ToString();
                                en.Nombre = reader["nombre"].ToString();
                                en.Correo = reader["correo"].ToString();
                                en.Telefono = reader["telefono"].ToString();
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
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();

                    //string query = "SELECT * FROM USUARIO WHERE correo = @correo";
                    string query = "SELECT TOP 1 * FROM USUARIO WHERE nombre = @nombre AND telefono = @telefono";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@telefono", en.Telefono);
                        command.Parameters.AddWithValue("@nombre", en.Nombre);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Nif = reader["tipo_usuario"].ToString();
                                en.Nombre = reader["nombre"].ToString();
                                en.Correo = reader["correo"].ToString();
                                en.Telefono = reader["telefono"].ToString();
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
    }
}