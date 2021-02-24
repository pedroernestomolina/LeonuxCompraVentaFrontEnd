using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Existencia
    {


        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public List<Deposito> depositos { get; set; }
        public string decimales { get; set; }
        public string empaque { get; set; }
        public int empaqueContenido { get; set; }


        public Existencia()
        {
            depositos = null;
            decimales = "0";
            empaque = "";
            empaqueContenido = 1;
            codigoPrd = "";
            nombrePrd = "";
        }

    }

}