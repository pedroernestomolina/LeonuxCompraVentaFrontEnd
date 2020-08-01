using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Existencia
    {


        public List<Deposito> depositos { get; set; }
        public string decimales { get; set; }


        public Existencia()
        {
            depositos = null;
            decimales = "0";
        }

    }

}