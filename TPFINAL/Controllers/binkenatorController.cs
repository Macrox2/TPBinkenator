﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFINAL.Models;

namespace TPFINAL.Controllers
{
    public class binkenatorController : Controller
    {
        // GET: binkenator
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Juego()
        {
            return View();
        }

        public ActionResult crearPregunta()
        {
            juego.respuestasTotal = BD.TraerRespuestas();
            juego.decisivas();
            juego.HacerRandom();
            ViewBag.pregunta = "es" + juego.ultimaRespuesta + "?";
            return View();
        }

        public ActionResult eliminarSegunRespuesta(string respuesta)
        {
            juego.FiltrarCorrectas(respuesta);
            return View();
        }
    }
}