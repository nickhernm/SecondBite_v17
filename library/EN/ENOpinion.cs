using library.CAD;

namespace library
{
    public class ENOpinion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Valoracion { get; set; }
        public string UsuarioCorreo { get; set; } // Clave foránea para la tabla Usuario

        public ENOpinion()
        {
        }

        public ENOpinion(int id, string descripcion, float valoracion, string usuarioCorreo)
        {
            Id = id;
            Descripcion = descripcion;
            Valoracion = valoracion;
            UsuarioCorreo = usuarioCorreo;
        }

        public bool Create()
        {
            CADOpinion cadOpinion = new CADOpinion();
            bool create = cadOpinion.Create(this);
            return create;
        }

        public bool Update()
        {
            CADOpinion cadOpinion = new CADOpinion();
            bool update = cadOpinion.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADOpinion cadOpinion = new CADOpinion();
            bool delete = cadOpinion.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADOpinion cadOpinion = new CADOpinion();
            bool read = cadOpinion.Read(this);
            return read;
        }
    }
}
