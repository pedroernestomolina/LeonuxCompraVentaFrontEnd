using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Sucursal.Entidad
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string nombreGrupo { get; set; }
        public string idPrecioManejar { get; set; }


        public Ficha()
        {
            id = "";
            idPrecioManejar = "";
            codigo = "";
            nombre = "";
            nombreGrupo = "";
        }

    }

}