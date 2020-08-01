using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Precio
    {

        public decimal precioNeto1 { get; set; }
        public decimal precioNeto2 { get; set; }
        public decimal precioNeto3 { get; set; }
        public decimal precioNeto4 { get; set; }
        public decimal precioNeto5 { get; set; }

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

        public decimal precioSugerido { get; set; }

        public Enumerados.EnumOferta ofertaActiva { get; set; }
        public decimal precioOferta { get; set; }
        public DateTime? inicioOferta { get; set; }
        public DateTime? finOferta { get; set; }

        public decimal precioFullDivisa1 { get; set; }
        public decimal precioFullDivisa2 { get; set; }
        public decimal precioFullDivisa3 { get; set; }
        public decimal precioFullDivisa4 { get; set; }
        public decimal precioFullDivisa5 { get; set; }


        public Precio()
        {
            precioNeto1 = 0.0m;
            precioNeto2 = 0.0m;
            precioNeto3 = 0.0m;
            precioNeto4 = 0.0m;
            precioNeto5 = 0.0m;

            contenido1 = 0;
            contenido2 = 0;
            contenido3 = 0;
            contenido4 = 0;
            contenido5 = 0;

            utilidad1 = 0.0m;
            utilidad2 = 0.0m;
            utilidad3 = 0.0m;
            utilidad4 = 0.0m;
            utilidad5 = 0.0m;

            precioSugerido = 0.0m;

            ofertaActiva = Enumerados.EnumOferta.SnDefinir;
            precioOferta = 0.0m;
            inicioOferta = null;
            finOferta = null;

            precioFullDivisa1 = 0.0m;
            precioFullDivisa2 = 0.0m;
            precioFullDivisa3 = 0.0m;
            precioFullDivisa4 = 0.0m;
            precioFullDivisa5 = 0.0m;
        }

    }

}