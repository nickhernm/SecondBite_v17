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
    }

}
