using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_v2.Models;

namespace Demo_v2.Controllers
{
    public class LugaresController : Controller
    {
        SpotItEntities spotItDB = new SpotItEntities();


        //
        // GET: /Lugares/
        public ActionResult Lugar(int id, int idMapa)
        {
            var lugares = spotItDB.Lugar.ToList();
            return View(lugares);
        }
        public ActionResult browserlugar(int id, int idMapa)
        {
            var lugar = spotItDB.Lugar.Find(id, idMapa);
            return View(lugar);
        }



        public ActionResult Index()
        {
            var categorias = spotItDB.Categoria.ToList();
            return View(categorias);
        }
        
        public ActionResult Browse(string categoria)
        {
            var aux = spotItDB.Categoria.Find(categoria);
            return View(aux);
        }

    }
}
