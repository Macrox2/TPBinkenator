﻿using System;
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

        public Filtro(string filtro)
        {
            _filtro = filtro;
        }

    }
}