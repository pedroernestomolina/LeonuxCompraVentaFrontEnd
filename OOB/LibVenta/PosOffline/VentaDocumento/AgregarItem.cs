﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.VentaDocumento
{
    
    public class AgregarItem
    {

        public string AutoProducto { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoSubGrupo { get; set; }
        public string AutoTasa { get; set; }


        public string CodigoPrd { get; set; }
        public string NombrePrd { get; set; }
        public string EmpaqueCodigo { get; set; }
        public string EmpaqueDescripcion { get; set; }
        public int EmpaqueContenido { get; set; }
        public string Decimales { get; set; }
        public decimal TasaIva { get; set; }
        public string Categoria { get; set; }
        public string Notas { get; set; }
        public decimal CostoCompraUnd { get; set; }
        public decimal CostoPromedioUnd { get; set; }
        public decimal PrecioSugerido { get; set; }
        public int DiasEmpaqueGarantia { get; set; }


        public decimal Cantidad { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal PorcDscto_1 { get; set; }
        public decimal PorcDscto_2 { get; set; }
        public decimal PorcDscto_3 { get; set; }
        public decimal MontoDscto_1 { get; set; }
        public decimal MontoDscto_2 { get; set; }
        public decimal MontoDscto_3 { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal MontoIva { get; set; }
        public decimal Total { get; set; }


        public decimal PrecioFinal { get; set; }
        public decimal PrecioItem { get; set; }
        public decimal PorctUtilidad { get; set; }
        public decimal MontoUtilidad { get; set; }


        public string TarifaPrecio { get; set; }
        public decimal CostoVenta { get; set; }
        public decimal CantidadUnd { get; set; }
        public decimal PrecioUnd { get; set; }

        public decimal TotalDescuento { get; set; }
        public bool EsPesado { get; set; }
        public string TipoIva { get; set; }

        public decimal CostoCompra { get; set; }
        public decimal CostoPromedio { get; set; }

    }

}