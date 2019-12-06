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
        public static bool terminoDecisivas=false;
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
                if (terminoDecisivas == false)
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
                    if (devolver.Count == 0)
                    {
                    terminoDecisivas = true;
                    }
                    listaActualFiltros = devolver;
                }
                else
                {
                    List<Filtro> devolver = new List<Filtro>();
                    primeravez = true;
                    listaActualRespuestas = respuestasTotal;
                }
        }

        public static void FiltrarCorrectas (string respuesta)
        {
            List<int> borrar = new List<int>();
            bool encontre=false;
            int id;
            int w = 0;
            if (respuesta == "si")
            {
                for (int z = 0; z < listaActualRespuestas.Count; z++)
                {
                    if (listaActualRespuestas[z].respuesta != ultimaRespuesta && ultimoFiltro == listaActualRespuestas[z].Filtro)
                    {
                        id = listaActualRespuestas[z].Id_Personaje;
                        borrar.Add(id);
                    }
                }
                int j = respuestasTotal.Count-1, k = borrar.Count-1, f=0;
                encontre = false;
                while (encontre == false)
                {
                    if (j>=0 && k>=0 && respuestasTotal[j].Id_Personaje == borrar[k])
                    {
                        respuestasTotal.RemoveAt(j);
                        if (respuestasTotal.Count == 0)
                        {
                            encontre = true;
                            adivinado = "NO";
                        }
                        f++;
                    }
                    if (respuestasTotal.Count <= filtrosTotales.Count)
                    {
                        adivinado = "SI";
                    }
                    if (j<0)
                    {
                        k--;
                        j = juego.respuestasTotal.Count-1;
                    }
                    j--;

                    if (k < 0)
                    {
                        encontre = true;
                    }
                }           
            }
            else
            {
                
            }
        }
            
    }
}