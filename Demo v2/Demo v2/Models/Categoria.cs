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
        [Key]
        public string nombre { get; set; }
    }
}