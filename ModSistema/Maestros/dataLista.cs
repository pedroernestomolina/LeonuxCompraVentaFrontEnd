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
        public string serie { get; set; }
        public string control { get; set; }
        public string correlativo { get; set; }
        public string estatus { get; set; }
        public bool IsActivo { get { return estatus.Trim().ToUpper() == "ACTIVO"; } }


        public dataLista(OOB.LibSistema.Vendedor.Entidad.Ficha it)
        {
            this.id = it.id;
            this.codigo = it.codigo;
            this.nombre= it.nombre;
            this.ciRif= it.ciRif;
            this.serie = "";
            this.control = "";
            this.correlativo = "";
            this.estatus = it.estatus;
        }

        public dataLista(OOB.LibSistema.Cobrador.Entidad.Ficha it)
        {
            this.id = it.id;
            this.codigo = it.codigo;
            this.nombre = it.nombre;
            this.ciRif = "";
            this.serie = "";
            this.control = "";
            this.correlativo = "";
            this.estatus = "Activo";
        }

        public dataLista(OOB.LibSistema.SerieFiscal.Entidad.Ficha it)
        {
            this.id = it.id;
            this.codigo = "";
            this.nombre = "";
            this.ciRif = "";
            this.serie = it.serie;
            this.control = it.control;
            this.correlativo = it.correlativo.ToString();
            this.estatus = it.estatus;
        }

    }

}