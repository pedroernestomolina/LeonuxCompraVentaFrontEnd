using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.OOB.Documento.Lista
{
    
    public class Filtro
    {

        public string idArqueo;
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string codSucursal { get; set; }
        public string codTipoDocumento { get; set; }


        public Filtro()
        {
            idArqueo = "";
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
            codSucursal = "";
            codTipoDocumento = "";
        }

    }

}