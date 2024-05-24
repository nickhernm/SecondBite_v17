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
	public class CADLinea
	{
        private string constring;

        public CADLinea()
		{
            constring = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            System.Diagnostics.Debug.WriteLine(constring);
        }

		public bool Create(ENLinea en)
		{
			return false;
		}

		public bool Delete(ENLinea en)
		{
			return false;
		}

		public bool Update(ENLinea en)
		{
			return false;
		}

		public bool Read(ENLinea en)
		{
            return true;
            /*try
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
            }*/
        }


        public List<ENLinea> ReadAllPed(ENLinea en)
        {
            try
            {
                List<ENLinea> listLinea = new List<ENLinea>();
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();

                    string query = "SELECT * FROM LINPED WHERE num_pedido = @num_pedido";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@num_pedido", en.pedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                                System.Diagnostics.Debug.WriteLine(reader.GetName(i) + "\t");
                            }
                            System.Diagnostics.Debug.WriteLine("-");

                            while (reader.Read())
                            {
                                ENLinea enLinea = new ENLinea();
                                ENPlato enPlato = new ENPlato();
                                enLinea.linea = Convert.ToInt32(reader["linea"].ToString());
                                enLinea.pedido = Convert.ToInt32(reader["num_pedido"].ToString());
                                enLinea.importe = float.Parse(reader["importe"].ToString());
                                enLinea.cantidad = float.Parse(reader["cantidad"].ToString());
                                enLinea.platoId = Convert.ToInt32(reader["plato"].ToString());
                                enPlato.Id = Convert.ToInt32(reader["plato"].ToString());
                                if (enPlato.Read())
                                {
                                    enLinea.plato = enPlato;
                                }
                                listLinea.Add(enLinea);
                                //System.Diagnostics.Debug.WriteLine(enLinea.emailPedido);
                                System.Diagnostics.Debug.WriteLine("sssss");

                                // Read each field in the current row
                                /*for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    // Get the value and convert it to a string
                                    object value = reader.GetValue(i);
                                    string stringValue = value != DBNull.Value ? value.ToString() : "NULL";

                                    if (i == 0)
                                    {
                                        System.Diagnostics.Debug.WriteLine(stringValue + " the id" + "\t");

                                    }
                                    System.Diagnostics.Debug.WriteLine(stringValue + "\t");
                                }*/
                                System.Diagnostics.Debug.WriteLine("");
                            }
                            return listLinea;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al leer el usuario. Error: {0}", ex.Message);
                return null;
            }
        }
    }
}

