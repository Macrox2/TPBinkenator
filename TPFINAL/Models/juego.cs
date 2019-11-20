using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public static class juego
    {
        public static List<Filtro> listaActualFiltros = new List<Filtro>();
        public static List<Respuesta> respuestasTotal = new List<Respuesta>();
        public static string ultimaRespuesta;
        public static string ultimoFiltro;
        public static int respuestasRestantes;
        public static bool primeravez=true;
        public static bool yaHechoDecisivas=false;
        public static string adivinado = "no";
        public static int personajeID;
        public static List<Filtro> filtrosTotales = new List<Filtro>();
        public static List<Respuesta> listaActualRespuestas = new List<Respuesta>();
        public static int nroDeResp;


        public static void HacerRandom ()
        {
            Random random = new Random();
            List<Respuesta> aux = new List<Respuesta>();
            int randomNumber = random.Next(0, listaActualFiltros.Count);
            for(int i = 0; i < respuestasTotal.Count; i++)
            { 
                if (listaActualFiltros[randomNumber].filtro == respuestasTotal[i].Filtro)
                {
                    aux.Add(respuestasTotal[i]);
                }
            }
            listaActualRespuestas = aux;
            int randomResp = random.Next(0, listaActualRespuestas.Count);
            ultimaRespuesta = listaActualRespuestas[randomResp].respuesta;
            respuestasRestantes--;
            ultimoFiltro = listaActualFiltros[randomNumber].filtro;
        }

        public static void decisivas()
        {
            if (primeravez == true || respuestasRestantes == 0)
            {
                if (yaHechoDecisivas == false)
                {
                    List<Filtro> devolver = new List<Filtro>();
                    for (int i = 0; i < filtrosTotales.Count; i++)
                    {
                        if (filtrosTotales[i].Decisivo == true)
                        {
                            devolver.Add(filtrosTotales[i]);
                        }
                    }
                    primeravez = false;
                    yaHechoDecisivas = true;
                    listaActualFiltros = devolver;
                }
                else
                {
                    if (respuestasRestantes > 0)
                    {
                        List<Filtro> devolver = new List<Filtro>();
                        for (int i = 0; i < respuestasTotal.Count; i++)
                        {
                            if (filtrosTotales[i].Decisivo == false)
                            {
                                devolver.Add(filtrosTotales[i]);
                            }
                        }
                        primeravez = true;
                        yaHechoDecisivas = false;
                        listaActualFiltros = devolver;
                    }
                    else
                    {
                        if (respuestasRestantes == 1)
                        {
                            adivinado = "si";
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
            if (respuesta == "si")
            {
                for (int z = 0; z < listaActualRespuestas.Count; z++)
                {
                    if (listaActualRespuestas[z].respuesta != ultimaRespuesta)
                    {
                        listaActualRespuestas.RemoveAt(z);             
                    }
                }
            }
            else
            {
                for (int z = 0; z < listaActualRespuestas.Count; z++)
                {
                    if (listaActualRespuestas[z].respuesta == ultimaRespuesta)
                    {
                        listaActualRespuestas.RemoveAt(z);
                    }
                }
            }
            
        }
    }
}