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
	public class CADCliente
	{
    	private string con;

    	public CADCliente()
    	{
    	    con = ConfigurationManager.ConnectionStrings["Database"].ToString();
    	}

    	public bool Create(ENCliente en)
    	{
    	    // Implementación del método Create
    	}

    	public bool Read(ENCliente en)
    	{
    	    // Implementación del método Read
    	}

    	public bool readFirst(ENCliente en)
    	{
    	    // Implementación del método readFirst
    	}

    	public bool readNext(ENCliente en)
    	{
    	    // Implementación del método readNext
    	}

    	public bool readPrev(ENCliente en)
    	{
    	    // Implementación del método readPrev
    	}

    	public bool Update(ENCliente en)
    	{
    	    // Implementación del método Update
    	}

    	public bool Delete(ENCliente en)
    	{
    	    // Implementación del método Delete
    	}
	}

}