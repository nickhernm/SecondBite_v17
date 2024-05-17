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
	public class CADUsuarioRestaurante
	{
        private string connectionString;

        public CADUsuarioRestaurante()
		{
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        }

        public bool Create(ENUsuarioRestaurante en)
		{
			return false;
			//TODO
		}

		public bool Delete(ENUsuarioRestaurante en)
		{
			return false;
			//TODO
		}

		public bool Update(ENUsuarioRestaurante en)
		{
			return false;
			//TODO
		}

		public bool Read(ENUsuarioRestaurante en)
		{
			return false;
			//TODO
		}
	}
}