﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Venta.Item.ActualizarCantidad.Aumentar
{
    
    public class Ficha
    {

        public int idOperador { get; set; }
        public int idItem { get; set; }
        public string autoProducto { get; set; }
        public string autoDeposito { get; set; }
        public decimal cantidad { get; set; }
        public decimal cantUndBloq { get; set; }
        public bool validarExistencia { get; set; }
        //
        public  decimal precioNeto { get; set; }
        public  string tarifaVenta { get; set; }
        public  decimal precioDivisa { get; set; }


        public Ficha()
        {
            idOperador = -1;
            idItem = -1;
            autoProducto = "";
            autoDeposito = "";
            cantidad = 0.0m;
            cantUndBloq = 0.0m;
            validarExistencia = false;
            precioNeto = 0.0m;
            precioDivisa = 0.0m;
            tarifaVenta = "";
        }
    
    }

}