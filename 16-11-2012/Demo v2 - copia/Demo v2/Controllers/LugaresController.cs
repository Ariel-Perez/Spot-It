using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_v2.Models;
using Demo_v2.Models.Packages;

namespace Demo_v2.Controllers
{
    public class LugaresController : Controller
    {
        public static SpotItEntities db = new SpotItEntities();

        //
        // GET: /Lugares/

        public ActionResult Index()
        {
            var categorias = db.Categoria.ToList();
            var facultades = db.Facultad.ToList();
            return View(new CategoriasYFacultades { Categorias = categorias, Facultades = facultades });
        }

        //
        // GET: /Lugares/Search?idCategoria=1

        public ActionResult Search(int idCategoria)
        {
            var cat = db.Categoria.Single(a => a.Id == idCategoria);
            return View(cat);
        }

        //
        // GET: /Lugares/Search?idFacultad=1

        public ActionResult SearchByFaculty(int idFacultad)
        {
            var fac = db.Facultad.Single(f => f.Id == idFacultad);
            return View(fac);
        }

        //
        // GET: /Lugares/Details?idLugar=3

        public ActionResult Details(int idLugar)
        {
            var lugar = db.Lugar.Single(a => a.Id == idLugar);
            return View(lugar);
        }

        //
        // GET: /Lugares/Show?idLugar=3&mensaje="hola!"

        public ActionResult Show(int idLugar, string mensaje = "Este link no viene con un mensaje :c")
        {
            var lugar = db.Lugar.Single(a => a.Id == idLugar);
            return View(new DynamicLinkInfo { Lugar = lugar, Mensaje = mensaje });
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
