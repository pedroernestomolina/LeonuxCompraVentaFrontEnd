using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.SucursalGrupo
{

    public class Ficha
    {

        public string auto { get; set; }
        public string nombre { get; set; }
        public string precioId { get; set; }
        public string precioDescripcion { get; set; }


        public string IdPrecioDesc { get { return precioId + " / " + precioDescripcion; } }

    }

}