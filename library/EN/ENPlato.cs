using System;
using System.Collections.Generic;

namespace library
{
    public class ENPlato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Alergenos { get; set; }
        public float Puntuacion { get; set; }
        public List<ENOpinion> Opiniones { get; set; }
        public int RestauranteId { get; set; }

        public ENPlato()
        {
            Opiniones = new List<ENOpinion>();
        }

        public List<ENPlato> ReadAll()
        {
            CADPlato cadPlato = new CADPlato();
            return cadPlato.ReadAll();
        }

        public bool Create()
        {
            CADPlato pla = new CADPlato();
            bool create = pla.Create(this);
            return create;
        }

        public bool Update()
        {
            CADPlato pla = new CADPlato();
            bool update = pla.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADPlato pla = new CADPlato();
            bool delete = pla.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADPlato pla = new CADPlato();
            bool read = pla.Read(this);
            return read;
        }

        public List<ENPlato> ObtenerPlatosRestaurante(int codigoRestaurante)
        {
            CADPlato cadPlato = new CADPlato();
            return cadPlato.ObtenerPlatosRestaurante(codigoRestaurante);
        }

        public List<ENPlato> ObtenerPlatosDestacados(int codigoRestaurante)
        {
            CADPlato cadPlato = new CADPlato();
            return cadPlato.ObtenerPlatosDestacados(codigoRestaurante);
        }

        public List<ENPlato> ObtenerPlatosRecomendados()
        {
            CADPlato cadPlato = new CADPlato();
            return cadPlato.ObtenerPlatosRecomendados();
        }

    }
}