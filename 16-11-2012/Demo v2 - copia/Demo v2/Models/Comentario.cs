using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Comentario
    {
        public virtual int LugarId { get; set; }
        public virtual int Numero { get; set; }
        public virtual int UsuarioId { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual string Texto { get; set; }

        public virtual Lugar Lugar { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}