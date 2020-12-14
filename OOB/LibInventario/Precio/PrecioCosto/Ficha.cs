using System;
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
        public decimal precioFull1 { get { return precioNeto1 * ((tasaIva / 100) + 1); } }
        public decimal precioNeto2 { get; set; }
        public decimal precioFull2 { get { return precioNeto2 * ((tasaIva / 100) + 1); } }
        public decimal precioNeto3 { get; set; }
        public decimal precioFull3 { get { return precioNeto3 * ((tasaIva / 100) + 1); } }
        public decimal precioNeto4 { get; set; }
        public decimal precioFull4 { get { return precioNeto4 * ((tasaIva / 100) + 1); } }
        public decimal precioNeto5 { get; set; }
        public decimal precioFull5 { get { return precioNeto5 * ((tasaIva / 100) + 1); } }

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
        public decimal precioNetoDivisa1 { get { return precioFullDivisa1 / ((tasaIva / 100)+1); } }
        public decimal precioFullDivisa2 { get; set; }
        public decimal precioNetoDivisa2 { get { return precioFullDivisa2 / ((tasaIva / 100) + 1); } }
        public decimal precioFullDivisa3 { get; set; }
        public decimal precioNetoDivisa3 { get { return precioFullDivisa3 / ((tasaIva / 100) + 1); } }
        public decimal precioFullDivisa4 { get; set; }
        public decimal precioNetoDivisa4 { get { return precioFullDivisa4 / ((tasaIva / 100) + 1); } }
        public decimal precioFullDivisa5 { get; set; }
        public decimal precioNetoDivisa5 { get { return precioFullDivisa5 / ((tasaIva / 100) + 1); } }

        public string fechaUltimaActCosto { get; set; }
        public string empCompra { get; set; }
        public int contempCompra { get; set; }
        public decimal costoUndDivisa { get; set; }
        public decimal costoUnd { get; set; }

    }

}