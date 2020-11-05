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

        public string autoId { get { return identidad.auto; } }
        public string ciRif { get { return identidad.ciRif; } }
        public string nombreRazonSocial { get { return identidad.nombreRazonSocial; } }
        public string direccionFiscal { get { return identidad.dirFiscal; } }


        public Ficha()
        {
            identidad = new Identificacion();
        }

    }

}