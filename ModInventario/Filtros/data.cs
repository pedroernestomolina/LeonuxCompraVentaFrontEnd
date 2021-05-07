using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Filtros
{
    
    public class data
    {

        public OOB.LibInventario.Deposito.Ficha depOrigen { get; set; }
        public OOB.LibInventario.Deposito.Ficha depDestino{ get; set; }
        public OOB.LibInventario.Concepto.Ficha concepto { get; set; }
        public Estatus estatus { get; set; }


        public data()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            depOrigen = null;
            depDestino = null;
            estatus = null;
            concepto = null;
        }

    }

}