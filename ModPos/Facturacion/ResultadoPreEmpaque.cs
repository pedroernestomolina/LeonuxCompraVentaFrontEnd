using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class ResultadoPreEmpaque
    {

        public bool IsPreEmpaque { get; set; }
        public string ItemCodigo { get; set; }
        public decimal Peso { get; set; }
        public decimal Precio { get; set; }


        public ResultadoPreEmpaque()
        {
            IsPreEmpaque = false;
            ItemCodigo = "";
            Peso = 0.0m;
            Precio = 0.0m;
        }

    }

}