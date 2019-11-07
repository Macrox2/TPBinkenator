using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public static class juego
    {
        public static List<Filtro> listaActual = new List<Filtro>();
        public static List<Respuesta> respuestasTotal = new List<Respuesta>();
        public static string ultimaRespuesta;
        public static int respuestasRestantes;
        public static bool primeravez=true;
        public static bool yaHechoDecisivas=false;
        public static string adivinado = "no";
        public static int personajeID;
        public static List<Filtro> filtrosTotales = new List<Filtro>();

        public static void HacerRandom ()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, listaActual.Count);
            for(int i = 0; i < respuestasTotal.Count; i++)
            {

            }
            string devolver = listaActual[randomNumber].respuesta;
            respuestasRestantes--;
            ultimaRespuesta = devolver;
        }
        public static void decisivas()
        {
            if (primeravez == true || respuestasRestantes == 0)
            {
                if (yaHechoDecisivas == false)
                {
                    List<Filtro> devolver = new List<Filtro>();
                    for (int i = 0; i < respuestasTotal.Count; i++)
                    {
                        if (filtrosTotales[i].Decisivo == true)
                        {
                            devolver.Add(filtrosTotales[i]);
                        }
                    }
                    primeravez = false;
                    yaHechoDecisivas = true;
                    listaActual = devolver;
                }
                else
                {
                    if (respuestasRestantes > 0)
                    {
                        List<Respuesta> devolver = new List<Respuesta>();
                        for (int i = 0; i < respuestasTotal.Count; i++)
                        {
                            if (respuestasTotal[i].Decisivo == false)
                            {
                                devolver.Add(respuestasTotal[i]);
                            }
                        }
                        primeravez = true;
                        yaHechoDecisivas = false;
                        listaActual = devolver;
                    }
                    else
                    {
                        if (respuestasRestantes == 1)
                        {
                            adivinado = "si";
                            //personajeID = respuestasRestantes[0].ID;
                        }
                        else
                        {
                            adivinado = "!!";
                        }
                    }
                }
            }
        }
        public static void FiltrarCorrectas (string respuesta)
        {
            List<Respuesta> devolver = new List<Respuesta>();
            string filtro="";
            int i=0;
            bool encontre = false;
            while (encontre == false)
            {
                if (listaActual[i].respuesta == ultimaRespuesta)
                {
                    filtro = listaActual[i].Filtro;
                    encontre = true;
                }
            }
            if (respuesta == "si")
            {
                for (int z = 0; z < listaActual.Count; z++)
                {
                    if (listaActual[z].Filtro == filtro)
                    {
                        if (listaActual[z].respuesta == ultimaRespuesta)
                        {
                            listaActual.RemoveAt(z);             
                        }
                    }
                }
            }
            else
            {
                for (int z = 0; z < listaActual.Count; z++)
                {
                    if (listaActual[z].Filtro == filtro)
                    {
                        if (listaActual[z].respuesta != ultimaRespuesta)
                        {
                            listaActual.RemoveAt(z);
                        }
                    }
                }
            }                                 
        }
    }
}