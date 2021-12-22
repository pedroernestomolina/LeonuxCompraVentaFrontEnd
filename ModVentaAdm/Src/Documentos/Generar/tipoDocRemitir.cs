using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Documentos.Generar
{
    
    public class tipoDocRemitir
    {

        public string id { get; set; }
        public string descripcion { get; set; }


        public tipoDocRemitir(string _id, string _desc)
        {
            this.id = _id;
            this.descripcion = _desc;
        }

    }

}