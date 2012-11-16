using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Apodo { get; set; }
        public virtual DateTime FechaRegistro { get; set; }
        public virtual int NumComentarios { get; set; }
        public virtual int NumFotos { get; set; }
        public virtual int NumSugerenciasLugares { get; set; }
        public virtual int NumEventosCreados { get; set; }
        public virtual int NumEventosAsistidos { get; set; }
        public virtual int NumFavoritos { get; set; }
        public virtual int NumGenteInvitada { get; set; }

        public virtual List<Comentario> Comentario { get; set; }
    }
}