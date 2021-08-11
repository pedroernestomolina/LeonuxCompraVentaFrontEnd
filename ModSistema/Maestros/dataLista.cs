using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros
{
    
    public class dataLista
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string ciRif { get; set; }
        public string estatus { get; set; }


        public dataLista(OOB.LibSistema.Vendedor.Entidad.Ficha it)
        {
            this.id = it.id;
            this.codigo = it.codigo;
            this.nombre= it.nombre;
            this.ciRif= it.ciRif;
        }

        public dataLista(OOB.LibSistema.Cobrador.Entidad.Ficha it)
        {
            this.id = it.id;
            this.codigo = it.codigo;
            this.nombre = it.nombre;
            this.ciRif = "";
        }

    }

}