using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Precio
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string descripcion { get; set; }

        public string IdDescripcion { get { return id + " / " + descripcion; } }

    }

}