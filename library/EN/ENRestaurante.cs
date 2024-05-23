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

namespace library {
    public class ENRestaurante
    {
        public int Cod { get; set; } // Clave primaria
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Tipo { get; set; }
        public float Puntuacion { get; set; }

        public ENRestaurante()
        {

        }

        public bool Create()
        {
            CADRestaurante res = new CADRestaurante();
            bool create = res.Create(this);
            return create;
        }

        public bool Update()
        {
            CADRestaurante res = new CADRestaurante();
            bool update = res.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADRestaurante res = new CADRestaurante();
            bool delete = res.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADRestaurante res = new CADRestaurante();
            bool read = res.Read(this);
            return read;
        }

        public List<ENRestaurante> ObtenerRestaurantes(string busqueda, string comunidad, string tipo, string puntuacion)
        {
            CADRestaurante cadRestaurante = new CADRestaurante();
            return cadRestaurante.ObtenerRestaurantes(busqueda, comunidad, tipo, puntuacion);
        }

        public List<ENRestaurante> ObtenerRestaurantes()
        {
            CADRestaurante cadRestaurante = new CADRestaurante();
            return cadRestaurante.ObtenerRestaurantes();
        }

        public List<string> ObtenerTipos()
        {
            CADRestaurante cadRestaurante = new CADRestaurante();
            return cadRestaurante.ObtenerTipos();
        }

        public List<string> ObtenerComunidades()
        {
            CADRestaurante cadRestaurante = new CADRestaurante();
            return cadRestaurante.ObtenerComunidades();
        }
    }
}
