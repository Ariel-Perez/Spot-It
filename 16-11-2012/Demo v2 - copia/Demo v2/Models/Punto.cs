using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Punto
    {
        public virtual int LugarId { get; set; }
        public virtual int NumPunto { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        public virtual Lugar Lugar { get; set; }
    }
}