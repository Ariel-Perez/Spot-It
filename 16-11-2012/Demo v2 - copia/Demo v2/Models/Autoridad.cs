using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Autoridad
    {
        public virtual int Id { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Mail { get; set; }

        public virtual List<TrabajaEn> TrabajaEn { get; set; }
    }
}