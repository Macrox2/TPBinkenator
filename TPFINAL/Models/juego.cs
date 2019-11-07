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
        public static int ultimaRespuesta;
        public static int respuestasRestantes;
        public static bool primeravez=true;
        public static bool yaHechoDecisivas=false;
        public static string adivinado = "no";
        public static int personajeID;
        public static List<Filtro> filtrosTotales = new List<Filtro>();
        public static List<Respuesta> ListaActualRespuestas = new List<Respuesta>();
        public static int nroDeResp;


        public static void HacerRandom ()
        {
            Random random = new Random();
            bool encontre;
            int z;
            List<Respuesta> aux = new List<Respuesta>();
            int randomNumber = random.Next(0, listaActualFiltros.Count);
            for(int i = 0; i < respuestasTotal.Count; i++)
            {
                z = 0;
                encontre = false;
                while(encontre==false&&z>0)
                {
                    if (listaActualFiltros[z].filtro == respuestasTotal[i].Filtro)
                    {
                        aux.Add(respuestasTotal[i]);
                        encontre = true;
                    }
                    z++;
                }
            }
            ListaActualRespuestas = aux;
        }

        public static void preguntaNueva()
        {

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
            int i=0;
            bool encontre = false;
            while (encontre == false)
            {
                if (listaActualFiltros[i].respuesta == ultimaRespuesta)
                {
                    filtro = listaActualFiltros[i].Filtro;
                    encontre = true;
                }
            }
            if (respuesta == "si")
            {
                for (int z = 0; z < listaActualFiltros.Count; z++)
                {
                    if (listaActualFiltros[z].Filtro == filtro)
                    {
                        if (listaActualFiltros[z].respuesta == ultimaRespuesta)
                        {
                            listaActualFiltros.RemoveAt(z);             
                        }
                    }
                }
            }
            else
            {
                for (int z = 0; z < listaActualFiltros.Count; z++)
                {
                    if (listaActualFiltros[z].Filtro == filtro)
                    {
                        if (listaActualFiltros[z].respuesta != ultimaRespuesta)
                        {
                            listaActualFiltros.RemoveAt(z);
                        }
                    }
                }
            }                                 
        }
    }
}