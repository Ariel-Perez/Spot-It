using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models.Packages
{
    public class CategoriasYFacultades
    {
        public virtual List<Categoria> Categorias { get; set; }
        public virtual List<Facultad> Facultades { get; set; }
    }
}