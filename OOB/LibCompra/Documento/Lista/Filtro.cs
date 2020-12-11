using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Lista
{
    
    public class Filtro
    {

        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }


        public Filtro()
        {
            Desde = null;
            Hasta = null;
        }

    }

}