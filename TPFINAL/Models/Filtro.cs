using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFINAL.Models
{
    public partial class Filtro
    {
        private string _filtro;
        private bool _decisivo;

        public Filtro() { }

        public Filtro(string filtro, bool decisivo)
        {
            _filtro = filtro;
            _decisivo = decisivo;
        }

        public string filtro { get => _filtro; set => _filtro = value; }
        public bool Decisivo { get => _decisivo; set => _decisivo = value; }
    }
}