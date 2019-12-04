using System;
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

            Personaje person = BD.TraerPersonajeXid(juego.personajeID);
            ViewBag.Foto = person.Ruta_Imagen;
            ViewBag.Nombre = person.Nombre_Personaje;
            return View();
        }

        public ActionResult crearPregunta()
        {
            if (juego.adivinado == "no"&&juego.terminoDecisivas==false)
            {
                juego.decisivas();
                juego.HacerRandom();
                ViewBag.pregunta = "es " + juego.ultimaRespuesta + "?";
                return View("juego");
            }
            else
            {
                if (juego.adivinado == "SI")
                {
                    return View("Fin");
                }
                else
                {
                    if (juego.adivinado == "NO")
                    {
                        return View("AgregarPersonaje");
                    }
                    else
                    {
                        juego.HacerRandom();
                        ViewBag.pregunta = "es " + juego.ultimaRespuesta + "?";
                        return View("juego");
                    }
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
        public ActionResult AgregarPersonaje()
        {
            ViewBag.Filtros = BD.TraerFiltros();
            return View();
        }
        public ActionResult AgregarPersonaje2()
        {
            ViewBag.Filtros = BD.TraerFiltros();
            return View();
        }
        [HttpPost]
        public ActionResult InsertarPersonaje(Personaje p, HttpPostedFileBase ImageFile)
        {
            
             p.Ruta_Imagen = ImageFile.FileName;
            BD.AgregarPersonaje(p);
            return View("AgregarPersonaje2");
        }
        [HttpPost]
        public ActionResult InsertarFiltros(string profesion, string sexo, string nombre, string pelo, string hobbie)
        {
            BD.InsertarFiltros(profesion,sexo,nombre,pelo,hobbie);
            return View("Inicio");
        }
    }
}
