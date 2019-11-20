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
            if (juego.primeravez == true)
            {
                return RedirectToAction("PrimeraVez");
            }
            else
            {
                return RedirectToAction("crearPregunta");
            }
        }

        public ActionResult Fin()
        {
            ViewBag.Foto = "";
            ViewBag.Nombre = "pedro";
            return View();
        }

        public ActionResult crearPregunta()
        {
            return RedirectToAction("eliminarSegunRespuesta");
            if (juego.adivinado == "no")
            {
                juego.HacerRandom();
                ViewBag.pregunta = "es " + juego.ultimaRespuesta + "?";
                return View("juego");
            }
            else
            {
                if (juego.adivinado == "si")
                {
                    //view ganado

                    return View();
                }
                else
                {
                    //view agregar

                    return View();
                }
            }
        }

        public ActionResult PrimeraVez()
        {
            juego.respuestasTotal = BD.TraerRespuestas();
            juego.filtrosTotales = BD.TraerFiltros();
            juego.decisivas();
            juego.HacerRandom();
            ViewBag.pregunta = "es " + juego.ultimaRespuesta + "?";
            return View("juego");
        }

        public ActionResult eliminarSegunRespuesta(string rta)
        {
            juego.FiltrarCorrectas(rta);
            return RedirectToAction("crearPregunta");
        }
    }
}