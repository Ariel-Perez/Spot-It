﻿using Demo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_v2.Controllers
{
    public class HomeController : Controller
    {
        SpotItEntities db = new SpotItEntities();
        public ActionResult Index()
        {
            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }
        public ActionResult Search()
        {

            return View();
        }

        public ActionResult Search2(string nombre,string tipo)
        {
            if (tipo == "Lugar")
            {
                var lug = db.Lugar.Single(a => a.Nombre == nombre);
                return View(lug);
            }
            else if (tipo == "Sala")
            {
                var lug = db.Lugar.Single(a => a.Nombre == nombre);
                return View(lug);
            }
            else
            {
                var lug = from Autoridad in db.Autoridad
                          where Autoridad.Apellido.Contains(nombre) || Autoridad.Nombre.Contains(nombre)
                          select Autoridad;
                return View(lug);

            }

        }
        public ActionResult Salas()
        {
            return View();
        }
    }
}
