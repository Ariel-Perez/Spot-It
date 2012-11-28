using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class ResultadosBusquedaSala
    {
        public virtual IEnumerable<Lugar> Salas { get; set; }
        public virtual bool[][] HorariosPedidos { get; set; }
    }
}