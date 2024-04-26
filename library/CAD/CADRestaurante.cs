﻿using System;
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
	public class CADRestaurante
	{
    	private string con;

    	public CADRestaurante()
    	{
    	    con = ConfigurationManager.ConnectionStrings["Database"].ToString();
    	}

    	public bool Create(ENRestaurante en)
    	{
    	    // Implementación del método Create
    	}

    	public bool Read(ENRestaurante en)
    	{
    	    // Implementación del método Read
    	}

    	public bool readFirst(ENRestaurante en)
    	{
    	    // Implementación del método readFirst
    	}

    	public bool readNext(ENRestaurante en)
    	{
    	    // Implementación del método readNext
    	}

    	public bool readPrev(ENRestaurante en)
    	{
    	    // Implementación del método readPrev
    	}

    	public bool Update(ENRestaurante en)
    	{
    	    // Implementación del método Update
    	}

    	public bool Delete(ENRestaurante en)
    	{
    	    // Implementación del método Delete
    	}
	}

}