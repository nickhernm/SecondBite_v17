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
	public class CADPedido
	{
        private string constring;
        public CADPedido()
        {

            constring = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            System.Diagnostics.Debug.WriteLine(constring);
        }
        public bool Create(ENPedido en)
		{
			return false;
			//TODO
		}

		public bool Delete(ENPedido en)
		{
			return false;
			//TODO
		}

		public bool Update(ENPedido en)
		{
			return false;
			//TODO
		}

		public bool Read(ENPedido en)
		{
			return false;
			//TODO
		}

        public List<ENPedido> ReadAll()
        {

            try
            {
                List<ENPedido> listPedido = new List<ENPedido>();
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    //string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario, id_metodo_pago) VALUES (@correo, @nombre, @telefono, @tipo_usuario, @id_metodo_pago)";
                    string query = "SELECT * FROM PEDIDO";
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
                                ENPedido enTemp = new ENPedido();
                                ENLinea enLinea = new ENLinea();
                                enLinea.pedido = Convert.ToInt32(reader["num_pedido"].ToString());
                                enTemp.numPedido = Convert.ToInt32(reader["num_pedido"].ToString());
                                enTemp.fechaPedido = reader["fecha"].ToString();
                                enTemp.emailPedido = reader["usuario"].ToString();
                                //enTemp.lineasPedido = enLinea.ReadAllPed();
                                listPedido.Add(enTemp);
                                System.Diagnostics.Debug.WriteLine(enTemp.emailPedido);
                                System.Diagnostics.Debug.WriteLine("sssss");
                            }
                            System.Diagnostics.Debug.WriteLine(listPedido[0].emailPedido);
                            System.Diagnostics.Debug.WriteLine(listPedido[1].emailPedido);
                            return listPedido;
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

        public List<ENPedido> ReadAllUser(ENUsuarioRestaurante enUsu)
        {

            try
            {
                List<ENPedido> listPedido = new List<ENPedido>();
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    //string query = "INSERT INTO USUARIO (correo, nombre, telefono, tipo_usuario, id_metodo_pago) VALUES (@correo, @nombre, @telefono, @tipo_usuario, @id_metodo_pago)";
                    string query = "SELECT * FROM PEDIDO";
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
                                ENPedido enTemp = new ENPedido();
                                ENLinea enLinea = new ENLinea();
                                enLinea.pedido = Convert.ToInt32(reader["num_pedido"].ToString());
                                enTemp.numPedido = Convert.ToInt32(reader["num_pedido"].ToString());
                                enTemp.fechaPedido = reader["fecha"].ToString();
                                enTemp.emailPedido = reader["usuario"].ToString();
                                //enTemp.lineasPedido = enLinea.ReadAllPed();
                                listPedido.Add(enTemp);
                                System.Diagnostics.Debug.WriteLine(enTemp.emailPedido);
                                System.Diagnostics.Debug.WriteLine("sssss");
                            }
                            System.Diagnostics.Debug.WriteLine(listPedido[0].emailPedido);
                            System.Diagnostics.Debug.WriteLine(listPedido[1].emailPedido);
                            return listPedido;
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

