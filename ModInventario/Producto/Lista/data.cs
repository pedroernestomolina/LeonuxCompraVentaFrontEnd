using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Lista
{
    
    public class data
    {

        private OOB.LibInventario.Producto.Data.Ficha rg;


        public string Auto { get { return rg.AutoId; } }
        public string Codigo { get { return rg.CodigoPrd; } }
        public string Producto { get { return rg.DescripcionPrd; } }
        public OOB.LibInventario.Producto.Enumerados.EnumEstatus Estatus { get { return rg.identidad.estatus ; } }
        public OOB.LibInventario.Producto.Data.Ficha FichaPrd { get { return rg; } }


        public data(OOB.LibInventario.Producto.Data.Ficha rg)
        {
            this.rg = rg;
        }

    }

}