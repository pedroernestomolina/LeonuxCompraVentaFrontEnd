using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.OOB.Sistema.TipoDocumento.Entidad
{
    
    public class Ficha
    {


        public string id { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }


        public Ficha()
        {
            id = "";
            descripcion = "";
            codigo = "";
        }

        public Ficha(string id, string desc,string cod)
            : this()
        {
            this.id = id;
            this.descripcion = desc;
            this.codigo = cod;
        }

    }

}