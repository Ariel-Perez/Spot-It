using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_v2.Models;

namespace Demo_v2.Controllers
{
    public class SalasController : Controller
    {
        SpotItEntities db { get { return LugaresController.db; } }

        string[] dias = new string[]
        {
            "Ninguno",
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"
        };

        //
        // GET: /Salas/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Salas/?Search=...
        public ActionResult Search(bool dia_1mod_1, bool dia_1mod_2, bool dia_1mod_3, bool dia_1mod_4, bool dia_1mod_5, bool dia_1mod_6, bool dia_1mod_7, bool dia_1mod_8,
                                    bool dia_2mod_1, bool dia_2mod_2, bool dia_2mod_3, bool dia_2mod_4, bool dia_2mod_5, bool dia_2mod_6, bool dia_2mod_7, bool dia_2mod_8,
                                    bool dia_3mod_1, bool dia_3mod_2, bool dia_3mod_3, bool dia_3mod_4, bool dia_3mod_5, bool dia_3mod_6, bool dia_3mod_7, bool dia_3mod_8,
                                    bool dia_4mod_1, bool dia_4mod_2, bool dia_4mod_3, bool dia_4mod_4, bool dia_4mod_5, bool dia_4mod_6, bool dia_4mod_7, bool dia_4mod_8,
                                    bool dia_5mod_1, bool dia_5mod_2, bool dia_5mod_3, bool dia_5mod_4, bool dia_5mod_5, bool dia_5mod_6, bool dia_5mod_7, bool dia_5mod_8,
                                    bool dia_6mod_1, bool dia_6mod_2, bool dia_6mod_3, bool dia_6mod_4, bool dia_6mod_5, bool dia_6mod_6, bool dia_6mod_7, bool dia_6mod_8,
                                    int capacity)
        {
            bool[][] array = new bool[6][];
            array[0] = new bool[8]{ dia_1mod_1,  dia_1mod_2,  dia_1mod_3,  dia_1mod_4,  dia_1mod_5,  dia_1mod_6,  dia_1mod_7,  dia_1mod_8};
            array[1] = new bool[8]{ dia_2mod_1,  dia_2mod_2,  dia_2mod_3,  dia_2mod_4,  dia_2mod_5,  dia_2mod_6,  dia_2mod_7,  dia_2mod_8};
            array[2] = new bool[8]{ dia_3mod_1,  dia_3mod_2,  dia_3mod_3,  dia_3mod_4,  dia_3mod_5,  dia_3mod_6,  dia_3mod_7,  dia_3mod_8};
            array[3] = new bool[8]{ dia_4mod_1,  dia_4mod_2,  dia_4mod_3,  dia_4mod_4,  dia_4mod_5,  dia_4mod_6,  dia_4mod_7,  dia_4mod_8};
            array[4] = new bool[8]{ dia_5mod_1,  dia_5mod_2,  dia_5mod_3,  dia_5mod_4,  dia_5mod_5,  dia_5mod_6,  dia_5mod_7,  dia_5mod_8};
            array[5] = new bool[8]{ dia_6mod_1,  dia_6mod_2,  dia_6mod_3,  dia_6mod_4,  dia_6mod_5,  dia_6mod_6,  dia_6mod_7,  dia_6mod_8};
            
            var salas = db.Lugar.Where(l => l.isSala).ToList();

            salas.RemoveAll(s => s.capacidad < capacity);
            string dia;
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(!array[i][j])
                        continue;

                    dia = dias[i + 1];
                    var horarios = db.Horario.Where(h=> h.Modulo == (j+1) && h.Dia == dia && h.tipo_actividad != " - ").ToList();
                    
                    salas.RemoveAll(s => horarios.Exists(h => h.LugarId == s.Id));
                }
            }

            return View(new ResultadosBusquedaSala { Salas = salas, HorariosPedidos = array });
        }

        //
        // GET: /Salas/Book?idSala=3
        public ActionResult Book(bool dia_1mod_1, bool dia_1mod_2, bool dia_1mod_3, bool dia_1mod_4, bool dia_1mod_5, bool dia_1mod_6, bool dia_1mod_7, bool dia_1mod_8,
                                    bool dia_2mod_1, bool dia_2mod_2, bool dia_2mod_3, bool dia_2mod_4, bool dia_2mod_5, bool dia_2mod_6, bool dia_2mod_7, bool dia_2mod_8,
                                    bool dia_3mod_1, bool dia_3mod_2, bool dia_3mod_3, bool dia_3mod_4, bool dia_3mod_5, bool dia_3mod_6, bool dia_3mod_7, bool dia_3mod_8,
                                    bool dia_4mod_1, bool dia_4mod_2, bool dia_4mod_3, bool dia_4mod_4, bool dia_4mod_5, bool dia_4mod_6, bool dia_4mod_7, bool dia_4mod_8,
                                    bool dia_5mod_1, bool dia_5mod_2, bool dia_5mod_3, bool dia_5mod_4, bool dia_5mod_5, bool dia_5mod_6, bool dia_5mod_7, bool dia_5mod_8,
                                    bool dia_6mod_1, bool dia_6mod_2, bool dia_6mod_3, bool dia_6mod_4, bool dia_6mod_5, bool dia_6mod_6, bool dia_6mod_7, bool dia_6mod_8,
                                    int idSala)
        {
            bool[][] array = new bool[6][];
            array[0] = new bool[8] { dia_1mod_1, dia_1mod_2, dia_1mod_3, dia_1mod_4, dia_1mod_5, dia_1mod_6, dia_1mod_7, dia_1mod_8 };
            array[1] = new bool[8] { dia_2mod_1, dia_2mod_2, dia_2mod_3, dia_2mod_4, dia_2mod_5, dia_2mod_6, dia_2mod_7, dia_2mod_8 };
            array[2] = new bool[8] { dia_3mod_1, dia_3mod_2, dia_3mod_3, dia_3mod_4, dia_3mod_5, dia_3mod_6, dia_3mod_7, dia_3mod_8 };
            array[3] = new bool[8] { dia_4mod_1, dia_4mod_2, dia_4mod_3, dia_4mod_4, dia_4mod_5, dia_4mod_6, dia_4mod_7, dia_4mod_8 };
            array[4] = new bool[8] { dia_5mod_1, dia_5mod_2, dia_5mod_3, dia_5mod_4, dia_5mod_5, dia_5mod_6, dia_5mod_7, dia_5mod_8 };
            array[5] = new bool[8] { dia_6mod_1, dia_6mod_2, dia_6mod_3, dia_6mod_4, dia_6mod_5, dia_6mod_6, dia_6mod_7, dia_6mod_8 };
            

            var sala = db.Lugar.Single(s => s.Id == idSala);
            if (sala.isSala)
                return View(new SolicitudReserva { Sala = sala, HorarioPedido = array });
            else
                return View(default(Lugar));
        }
    }
}
