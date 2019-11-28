using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TPFINAL.Models
{
    public class AgregarPersonaje
    {
        private string _filtro;
        private bool _decisivo;
        private int _Id_Personaje;
        private string _Nombre_Personaje;
        private string _Ruta_Imagen;

        public string filtro { get => _filtro; set => _filtro = value; }
        public bool Decisivo { get => _decisivo; set => _decisivo = value; }

        
        public AgregarPersonaje(int id_Personaje, string nombre_Personaje, string ruta_Imagen, string filtro, bool decisivo)
        {
            Id_Personaje = id_Personaje;
            Nombre_Personaje = nombre_Personaje;
            Ruta_Imagen = ruta_Imagen;
            _filtro = filtro;
            _decisivo = decisivo;
        }
         public AgregarPersonaje(string filtro, bool decisivo)
        {
            _filtro = filtro;
            _decisivo = decisivo;
        }
        public AgregarPersonaje(int id_Personaje, string nombre_Personaje, string ruta_Imagen)
        {
            Id_Personaje = id_Personaje;
            Nombre_Personaje = nombre_Personaje;
            Ruta_Imagen = ruta_Imagen;
        }
        public AgregarPersonaje()
        {
        }
    

        public int Id_Personaje { get => Id_Personaje; set => Id_Personaje = value; }
        [DisplayName("Nombre")]
        public string Nombre_Personaje { get => Nombre_Personaje; set => Nombre_Personaje = value; }
        [DisplayName("Foto")]
        public string Ruta_Imagen { get => Ruta_Imagen; set => Ruta_Imagen = value; }

       

    }
}