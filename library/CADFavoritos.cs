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
    	private string connection;

    	public CADFavoritos()
    	{
    	    connection = ConfigurationManager.ConnectionStrings["BDD"].ToString();
    	}

    	public bool Create(ENFavoritos en)
    	{

    	}

    	public bool Update(ENFavoritos en)
    	{

    	}

    	public bool Read(ENFavoritos en)
    	{

    	}

    	public bool Delete(ENFavoritos en)
    	{

    	}

    	public bool readFirst(ENFavoritos en)
    	{

    	}

    	public bool readNext(ENFavoritos en)
    	{

    	}

    	public bool readPrev(ENFavoritos en)
    	{

    	}

    	public bool readAllClt(ENFavoritos en)
    	{
			//Lee todos los platos del cliente
    	}

	}

}
