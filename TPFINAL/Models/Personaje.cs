using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace TPFINAL.Models
{
    public class Personaje
    {
        public Personaje() { }

        private int _Id_Personaje;
        private string _Nombre_Personaje;
        private string _Ruta_Imagen;
        

        public int Id_Personaje { get => _Id_Personaje; set => _Id_Personaje = value; }
        [DisplayName("Nombre")]
        public string Nombre_Personaje { get => _Nombre_Personaje; set => _Nombre_Personaje = value; }
        [DisplayName("Foto")]
        public string Ruta_Imagen{ get => _Ruta_Imagen; set => _Ruta_Imagen = value; }

        public Personaje(int id_Personaje, string nombre_Personaje, string ruta_Imagen)
        {
            Id_Personaje = id_Personaje;
            Nombre_Personaje = nombre_Personaje;
            Ruta_Imagen = ruta_Imagen;
        }
    }
}