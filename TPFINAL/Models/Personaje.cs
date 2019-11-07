using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public class Personaje
    {
        public Personaje() { }

        private int _Id_Personaje;
        private string _Nombre_Personaje;
        private string _Ruta_Imagen;

        public int Id_Personaje { get => Id_Personaje; set => Id_Personaje = value; }
        public string Nombre_Personaje { get => Nombre_Personaje; set => Nombre_Personaje = value; }
        public string Ruta_Imagen { get => Ruta_Imagen; set => Ruta_Imagen = value; }

        public Personaje(int id_Personaje, string nombre_Personaje, string ruta_Imagen)
        {
            Id_Personaje = id_Personaje;
            Nombre_Personaje = nombre_Personaje;
            Ruta_Imagen = ruta_Imagen;
        }
    }
}