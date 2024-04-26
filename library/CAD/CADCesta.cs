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
	public class CADCesta
	{
    	private string connection;

    	public CADCesta()
    	{
    	    connection = ConfigurationManager.ConnectionStrings["BDD"].ToString();
    	}

    	public bool Create(ENCesta en)
    	{

    	}

    	public bool Update(ENCesta en)
    	{

    	}

    	public bool Read(ENCesta en)
    	{

    	}

    	public bool Delete(ENCesta en)
    	{

    	}

    	public bool readFirst(ENCesta en)
    	{

    	}

    	public bool readNext(ENCesta en)
    	{

    	}

    	public bool readPrev(ENCesta en)
    	{

    	}

    	public bool readAllClt(ENCesta en)
    	{
			//Lee todos los platos del cliente
    	}

	}

}
