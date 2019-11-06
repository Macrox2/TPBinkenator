using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public static class juego
    {
        public static List<Respuesta> respuestasDecisivas = new List<Respuesta>();
        public static List<Respuesta> respuestasTotal = new List<Respuesta>();
        public static string ultimaRespuesta;

        public static void HacerRandom ()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, respuestasDecisivas.Count);
            string devolver = respuestasDecisivas[randomNumber].respuesta;
            ultimaRespuesta = devolver;
        }
        public static void decisivas()
        {
            List<Respuesta> devolver=new List<Respuesta>();
            for(int i = 0; i < respuestasTotal.Count; i++)
            {
                if (respuestasTotal[i].Decisivo == true)
                {
                    devolver.Add(respuestasTotal[i]);
                }
            }
            respuestasDecisivas = devolver;
        }
        public static void FiltrarCorrectas (bool respuesta)
        {
            List<Respuesta> devolver = new List<Respuesta>();
             string filtro="";
            int i=0;
            bool encontre = false;
            while (i < respuestasTotal.Count && encontre == false)
            {
                if (respuestasTotal[i].respuesta == ultimaRespuesta)
                {
                    filtro = respuestasTotal[i].Filtro;
                    encontre = true;
                }
            }85
            if (respuesta == false)
            {
                for (int z = 0; z < respuestasTotal.Count; z++)
                {
                    if (respuestasTotal[z].Filtro == filtro)
                    {
                        if (respuestasTotal[z].respuesta == ultimaRespuesta)
                        {
                            respuestasTotal.RemoveAt(z);             
                        }
                    }
                }
            }
            else
            {
                for (int z = 0; z < respuestasTotal.Count; z++)
                {
                    if (respuestasTotal[z].Filtro != filtro)
                    {
                        if (respuestasTotal[z].respuesta == ultimaRespuesta)
                        {
                            respuestasTotal.RemoveAt(z);
                        }
                    }
                }
            }                                 
        }
    }
}