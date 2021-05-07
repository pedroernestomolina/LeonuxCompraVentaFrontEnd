﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    
    public class data
    {

        public class Negocio 
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string CiRif { get; set; }
            public string Telefonos { get; set; }

            public Negocio()
            {
                Nombre = "";
                Direccion = "";
                CiRif = "";
                Telefonos = "";
            }
        }

        public class Encabezado
        {
            public string DocumentoNombre { get; set; }
            public string DocumentoNro { get; set; }
            public DateTime DocumentoFecha { get; set; }
            public string DocumentoControl { get; set; }
            public string DocumentoSerie { get; set; }
            public string DocumentoCondicionPago { get; set; }
            public DateTime DocumentoFechaVencimiento { get; set; }
            public int DocumentoDiasCredito { get; set; }
            public string DocumentoAplica { get; set; }

            public string NombreCli { get; set; }
            public string DireccionCli { get; set; }
            public string CiRifCli { get; set; }
            public string CodigoCli { get; set; }

            public decimal FactorCambio { get; set; }
            public decimal SubTotal { get; set; }
            public decimal Descuento { get; set; }
            public decimal Total { get; set; }
            public decimal TotalDivisa { get; set; }


            public Encabezado()
            {
                NombreCli = "";
                DireccionCli = "";
                CiRifCli = "";
                CodigoCli = "";

                DocumentoAplica = "";
                DocumentoCondicionPago = "";
                DocumentoControl = "";
                DocumentoDiasCredito = 0;
                DocumentoFecha = DateTime.Now.Date;
                DocumentoFechaVencimiento = DateTime.Now.Date;
                DocumentoNombre = "";
                DocumentoNro = "";
                DocumentoSerie = "";

                FactorCambio = 0.0m;
                SubTotal = 0.0m;
                Descuento = 0.0m;
                Total = 0.0m;
                TotalDivisa = 0.0m;
            }
        }

        public class Item
        {
            public string NombrePrd { get; set; }
            public string CodigoPrd { get; set; }
            public decimal Cantidad { get; set; }
            public string Empaque { get; set; }
            public int Contenido { get; set; }
            public string DepositoCodigo { get; set; }
            public string DepositoDesc { get; set; }
            public decimal Precio { get; set; }
            public decimal PrecioDivisa { get; set; }
            public decimal Importe { get; set; }
            public decimal ImporteDivisa { get; set; }
            public decimal TotalUnd { get; set; }


            public Item()
            {
                NombrePrd = "";
                CodigoPrd = "";
                Cantidad = 0.0m;
                Empaque = "";
                Contenido = 0;
                DepositoCodigo = "";
                DepositoDesc = "";
                Precio = 0.0m;
                PrecioDivisa = 0.0m;
                Importe = 0.0m;
                ImporteDivisa = 0.0m;
                TotalUnd = 0.0m;
            }
        }


        public Negocio negocio { get; set; }
        public Encabezado encabezado { get; set; }
        public List<Item> item { get; set; }

    }

}
