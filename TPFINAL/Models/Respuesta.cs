using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public partial class Respuesta
    {
        private string _filtro;
        private int _id_Personaje;
        private string _Respuesta;

        public Respuesta()
        {
        }

        public Respuesta(string filtro, int id_Personaje, string Respuesta)
        {
            _filtro = filtro;
            _id_Personaje = id_Personaje;
            _Respuesta = Respuesta;
        }

        public string Filtro { get => _filtro; set => _filtro = value; }
        public int Id_Personaje { get => _id_Personaje; set => _id_Personaje = value; }
        public string respuesta { get => _Respuesta; set => _Respuesta = value; }
    }
}