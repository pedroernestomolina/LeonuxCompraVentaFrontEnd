using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor.Data
{
    
    public class Identificacion
    {

        public string auto { get; set; }
        public string autoGrupo { get; set; }
        public string autoEstado { get; set; }

        public string ciRif { get; set; }
        public string codigo { get; set; }
        public string nombreRazonSocial { get; set; }
        public string dirFiscal { get; set; }
        public string telefono { get; set; }
        public string nombreGrupo { get; set; }
        public string nombreEstado { get; set; }
        public string nombreContacto { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }

    }

}