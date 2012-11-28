using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Demo_v2.Models
{
    public class Lugar
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int? FacultadId { get; set; }
        public virtual int? LugarId { get; set; }

        public virtual int capacidad { get; set; }
        public virtual bool isSala { get; set; }

        public virtual Lugar LugarContenedor { get; set; }

        public virtual Facultad Facultad { get; set; }
        public virtual List<Categoria> Categoria { get; set; }
        public virtual List<Comentario> Comentario { get; set; }

        public virtual List<Horario> Horario { get; set; }
    }
}