﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.AgregarEditar.CodAlterno
{
    
    public class data
    {
        private string CodigoAlterno;


        public string codigo { get; set; }


        public data()
        {
            codigo = "";
        }

        public data(string CodigoAlterno)
            :this()
        {
            // TODO: Complete member initialization
            this.codigo = CodigoAlterno;
        }

    }

}