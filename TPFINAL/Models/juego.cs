using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public static class juego
    {
        public static List<Respuesta> listaActual = new List<Respuesta>();
        public static List<Respuesta> respuestasTotal = new List<Respuesta>();
        public static string ultimaRespuesta;
        public static int respuestasRestantes;
        public static bool primeravez=true;
        public static bool decisivas=false;


        public static void HacerRandom ()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, listaActual.Count);
            string devolver = listaActual[randomNumber].respuesta;
            respuestasRestantes--;
            ultimaRespuesta = devolver;
        }
        public static void decisivas()
        {
            if (primeravez == true || respuestasRestantes == 0)
            {
                if (decisivas == false)
                {
                    List<Respuesta> devolver = new List<Respuesta>();
                    for (int i = 0; i < respuestasTotal.Count; i++)
                    {
                        if (respuestasTotal[i].Decisivo == true)
                        {
                            devolver.Add(respuestasTotal[i]);
                        }
                    }
                    primeravez = false;
                    decisivas = true;
                    listaActual = devolver;
                }
                else
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
                    decisivas = false;
                    listaActual = devolver;
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