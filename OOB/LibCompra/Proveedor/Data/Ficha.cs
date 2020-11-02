using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor.Data
{
    
    public class Ficha
    {

        public Identificacion identidad { get; set; }


        public Ficha()
        {
            identidad = new Identificacion();
        }

    }

}