using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations; 

namespace Demo_v2.Models
{
    public class Categoria
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }

        public virtual List<Lugar> Lugar { get; set; }

        protected string Greetings()
        {
            return ("Hello World!");
        }
    }
}