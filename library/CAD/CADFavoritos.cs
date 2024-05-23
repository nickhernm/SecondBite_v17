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
using System.Runtime.Remoting.Messaging;

namespace library
{

	public class CADFavoritos
	{

        private string constring;
        public CADFavoritos()
    	{
            constring = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            System.Diagnostics.Debug.WriteLine(constring);
        }

    	public bool Create(ENFavoritos en)
    	{
            return false;
            //TODO
        }

        public bool Update(ENFavoritos en)
    	{
            return false;
            //TODO
        }

        public bool Read(ENFavoritos en)
    	{
            return false;
            //TODO
        }

        public bool Delete(ENFavoritos en)
    	{
            return false;
            //TODO
        }


        public List<ENFavoritos> ReadAll()
        {

            try
            {
                List<ENFavoritos> listaFavoritos = new List<ENFavoritos>();
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    //string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario, id_metodo_pago) VALUES (@correo, @nombre, @telefono, @tipo_usuario, @id_metodo_pago)";
                    string query = "SELECT * FROM FAVORITOS";
                    //string query = "SELECT * from Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

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
                                ENFavoritos enTemp = new ENFavoritos();
                                ENUsuarioRestaurante enUsu = new ENUsuarioRestaurante();
                                enUsu.Correo = reader["usuario"].ToString();
                                enTemp.id = Convert.ToInt32(reader["id"].ToString());
                                enTemp.usuario = enUsu;
                                listaFavoritos.Add(enTemp);
                                System.Diagnostics.Debug.WriteLine(enTemp.id);
                                System.Diagnostics.Debug.WriteLine("sssss");
                            }
                            System.Diagnostics.Debug.WriteLine(listaFavoritos[0]);
                            return listaFavoritos;
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


        public List<ENPlato> ReadFavoritosUsu(ENFavoritos enFav)
        {
            System.Diagnostics.Debug.WriteLine("enUsu.Correo");
            ENUsuarioRestaurante enUsu = enFav.usuario;
            List<ENPlato> listaPlatos = new List<ENPlato>();
            try
            {

                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    string query = "SELECT TOP 1 * FROM FAVORITOS WHERE usuario = @usuario";
                    System.Diagnostics.Debug.WriteLine("enUsu.CorreoADW");
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", enUsu.Correo);
                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            System.Diagnostics.Debug.WriteLine("enFav.id");
                            if (reader1.Read())
                            {
                                System.Diagnostics.Debug.WriteLine("enFav.id");

                                System.Diagnostics.Debug.WriteLine("aderd: " + reader1["usuario"].ToString());
                                enUsu.Correo = reader1["usuario"].ToString();
                                System.Diagnostics.Debug.WriteLine("adwdrrr: " + enUsu.Correo);
                                enFav.id = Convert.ToInt32(reader1["id"].ToString());
                                enFav.usuario = enUsu;
                                connection.Close();
                                try
                                {
                                    

                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine("Error readion pedidos. Error: {0}", ex.Message);
                                    return null;
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("awdwadawd");
                                return null;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error readion pedidos. Error: {0}", ex.Message);
                return null;
            }

            try
            {
                using (SqlConnection connection2 = new SqlConnection(constring))
                {
                    connection2.Open();
                    string query2 = "SELECT * FROM PLATO_FAVORITOS WHERE id_f = @id_f";
                    System.Diagnostics.Debug.WriteLine("enFav.id");
                    System.Diagnostics.Debug.WriteLine("daw: " + enFav.id);
                    using (SqlCommand command2 = new SqlCommand(query2, connection2))
                    {
                        System.Diagnostics.Debug.WriteLine("enFav.ided");
                        command2.Parameters.AddWithValue("@id_f", enFav.id);
                        System.Diagnostics.Debug.WriteLine("enFav.ided");
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                                System.Diagnostics.Debug.WriteLine(reader.GetName(i) + "\t");
                            }
                            System.Diagnostics.Debug.WriteLine("-");


                            // Check if there are rows to read
                            System.Diagnostics.Debug.WriteLine("rtrte");
                            while (reader.Read())
                            {
                                System.Diagnostics.Debug.WriteLine("qweuj");
                                ENPlato enPlato = new ENPlato();
                                System.Diagnostics.Debug.WriteLine("qweuj" + reader["id_p"].ToString());
                                enPlato.Id = Convert.ToInt32(reader["id_p"].ToString());
                                System.Diagnostics.Debug.WriteLine("awdrttyh");
                                if (enPlato.Read())
                                {
                                    System.Diagnostics.Debug.WriteLine("thdhdrgdrgdr");
                                    listaPlatos.Add(enPlato);
                                }

                                System.Diagnostics.Debug.WriteLine("sssss");
                                System.Diagnostics.Debug.WriteLine("");
                            }
                            System.Diagnostics.Debug.WriteLine("nvnvgn");
                            return listaPlatos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error readion wadawd. Error: {0}", ex.Message);
                return null;
            }

            }
    }

}
