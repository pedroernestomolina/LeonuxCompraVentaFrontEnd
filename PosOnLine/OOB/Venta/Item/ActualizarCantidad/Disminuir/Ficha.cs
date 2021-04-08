﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Venta.Item.ActualizarCantidad.Disminuir
{
    
    public class Ficha
    {

        public int idOperador { get; set; }
        public int idItem { get; set; }
        public string autoProducto { get; set; }
        public string autoDeposito { get; set; }
        public decimal cantidad { get; set; }
        public decimal cantUndBloq { get; set; }


        public Ficha()
        {
            idOperador = -1;
            idItem = -1;
            autoProducto = "";
            autoDeposito = "";
            cantidad = 0.0m;
            cantUndBloq = 0.0m;
        }

    }

}