using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace library
{
    public class CADOpinionPlato
    {
        private string constring;

        public CADOpinionPlato()
        {
            constring = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            System.Diagnostics.Debug.WriteLine(constring);
        }

        public bool Create(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "INSERT INTO OPINION_PLATO (id_p, id_o) VALUES (@IdPlato, @IdOpinion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);
                    command.Parameters.AddWithValue("@IdOpinion", en.IdOpinion);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public bool Update(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "UPDATE OPINION_PLATO SET id_o = @IdOpinion WHERE id_p = @IdPlato";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);
                    command.Parameters.AddWithValue("@IdOpinion", en.IdOpinion);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public bool Delete(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "DELETE FROM OPINION_PLATO WHERE id_p = @IdPlato";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public bool Read(ENOpinionPlato en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "SELECT * FROM OPINION_PLATO WHERE id_p = @IdPlato";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPlato", en.IdPlato);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Asignar valores leídos a las propiedades del objeto ENOpinionPlato
                        en.IdOpinion = Convert.ToInt32(reader["id_o"]);
                        return true;
                    }
                    else
                    {
                        return false; // No se encontró ninguna opinión para el plato
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                return false;
            }
        }

        public List<ENOpinion> ReadAll(ENPlato en)
        {

            try
            {
                List<ENOpinion> listOpinion = new List<ENOpinion>();
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    //string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario, id_metodo_pago) VALUES (@correo, @nombre, @telefono, @tipo_usuario, @id_metodo_pago)";
                    string query = "SELECT * FROM PLATO_OPINION WHERE id_p = @id_p";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_p", en.Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                                System.Diagnostics.Debug.WriteLine(reader.GetName(i) + "\t");
                            }
                            System.Diagnostics.Debug.WriteLine("-");


                            // Check if there are rows to read
                            while (reader.Read())
                            {
                                // Read each field in the current row
                                ENOpinion enTemp = new ENOpinion();
                                enTemp.Id = Convert.ToInt32(reader["id"].ToString());
                                enTemp.Valoracion = float.Parse(reader["valoracion"].ToString());
                                enTemp.Descripcion = reader["descripcion"].ToString();
                                enTemp.UsuarioCorreo = reader["usuario"].ToString();
                                listOpinion.Add(enTemp);
                                System.Diagnostics.Debug.WriteLine(enTemp.UsuarioCorreo);
                                System.Diagnostics.Debug.WriteLine("sssss");
                            }
                            System.Diagnostics.Debug.WriteLine(listOpinion[0].Descripcion);
                            System.Diagnostics.Debug.WriteLine(listOpinion[1].Descripcion);
                            return listOpinion;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error readion pedidos. Error: {0}", ex.Message);
                return null;
            }


        }
    }
}
