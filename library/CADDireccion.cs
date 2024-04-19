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
	public class CADDireccion
	{
    	private string con;

    	public CADDireccion()
    	{
    	    con = ConfigurationManager.ConnectionStrings["Database"].ToString();
    	}

    	public bool Create(ENDireccion en)
    	{
    	    // Implementación del método Create
    	}

    	public bool Read(ENDireccion en)
    	{
    	    // Implementación del método Read
    	}

    	public bool readFirst(ENDireccion en)
    	{
    	    // Implementación del método readFirst
    	}

    	public bool readNext(ENDireccion en)
    	{
    	    // Implementación del método readNext
    	}

    	public bool readPrev(ENDireccion en)
    	{
    	    // Implementación del método readPrev
    	}

    	public bool Update(ENDireccion en)
    	{
    	    // Implementación del método Update
    	}

    	public bool Delete(ENDireccion en)
    	{
    	    // Implementación del método Delete
    	}
	}

}