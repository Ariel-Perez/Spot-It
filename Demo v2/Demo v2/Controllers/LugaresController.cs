﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_v2.Models;

namespace Demo_v2.Controllers
{
    public class LugaresController : Controller
    {
        SpotItEntities db = new SpotItEntities();

        //
        // GET: /Lugares/

        public ActionResult Index()
        {
            var categorias = db.Categoria.ToList();
            return View(categorias);
        }

        //
        // GET: /Lugares/Search?categoriaId=1

        public ActionResult Search(int categoriaId)
        {
            var cat = db.Categoria.Single(a => a.Id == categoriaId);
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
