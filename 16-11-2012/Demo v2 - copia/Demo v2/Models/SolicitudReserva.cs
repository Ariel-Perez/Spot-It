using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class SolicitudReserva
    {
        public Lugar Sala { get; set; }
        public bool[][] HorarioPedido { get; set; }
    }
}