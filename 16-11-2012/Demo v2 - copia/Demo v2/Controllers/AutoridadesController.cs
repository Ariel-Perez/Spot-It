using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_v2.Models;

namespace Demo_v2.Controllers
{
    public class AutoridadesController : Controller
    {
        SpotItEntities db { get { return LugaresController.db; } }

        //
        // GET: /Autoridades/

        public ActionResult Index()
        {
            var categorias = db.Categoria.ToList();
            return View(categorias);
        }

        //
        // GET: /Autoridades/Search?idCargo=1

        public ActionResult Search(int idCargo)
        {
            var cat = db.Categoria.Single(a => a.Id == idCargo);
            return View(cat);
        }

        //
        // GET: /Lugares/Details?idLugar=3

        public ActionResult Details(int idLugar)
        {
            var lugar = db.Lugar.Single(a => a.Id == idLugar);
            return View(lugar);
        }

    }
}
