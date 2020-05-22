using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.Inventario.Precio
{
    
    public class Ficha
    {

        public string Id { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal UtilidadMargen { get; set; }
        public int ContEmpVenta { get; set; }
        public string DescEmpVenta { get; set; }
        public string Decimales { get; set; }

    }

}