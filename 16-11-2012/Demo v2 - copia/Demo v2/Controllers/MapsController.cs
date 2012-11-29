using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_v2.Models;

namespace Demo_v2.Controllers
{
    public class MapsController : Controller
    {

        public static SpotItEntities db = new SpotItEntities();
        //
        // GET: /Maps/
        public ActionResult Map()
        {
            try
            {
                var categorias = db.Categoria.ToList();
                return View(categorias);
            }
            catch { return View(new List<Categoria> { }); }
            
            
        }

        //
        // GET: /Maps/place
        public ActionResult place()
        {
            return View();
        }

        public string algo { get { return "cosa"; } }
      

    }
}
