﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Precio.PrecioCosto
{
    
    public class Ficha
    {

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nombreTasaIva { get; set; }
        public decimal tasaIva { get; set; }

        public string etiqueta1 { get; set; }
        public string etiqueta2 { get; set; }
        public string etiqueta3 { get; set; }
        public string etiqueta4 { get; set; }
        public string etiqueta5 { get; set; }

        public decimal precioNeto1 { get; set; }
        public decimal precioNeto2 { get; set; }
        public decimal precioNeto3 { get; set; }
        public decimal precioNeto4 { get; set; }
        public decimal precioNeto5 { get; set; }

        public string autoEmp1 { get; set; }
        public string autoEmp2 { get; set; }
        public string autoEmp3 { get; set; }
        public string autoEmp4 { get; set; }
        public string autoEmp5 { get; set; }

        public int contenido1 { get; set; }
        public int contenido2 { get; set; }
        public int contenido3 { get; set; }
        public int contenido4 { get; set; }
        public int contenido5 { get; set; }

        public decimal utilidad1 { get; set; }
        public decimal utilidad2 { get; set; }
        public decimal utilidad3 { get; set; }
        public decimal utilidad4 { get; set; }
        public decimal utilidad5 { get; set; }

        public OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }

        public decimal precioFullDivisa1 { get; set; }
        public decimal precioFullDivisa2 { get; set; }
        public decimal precioFullDivisa3 { get; set; }
        public decimal precioFullDivisa4 { get; set; }
        public decimal precioFullDivisa5 { get; set; }

        public string fechaUltimaActCosto { get; set; }
        public string empCompra { get; set; }
        public int contempCompra { get; set; }
        public decimal costoUndDivisa { get; set; }
        public decimal costoUnd { get; set; }

    }

}