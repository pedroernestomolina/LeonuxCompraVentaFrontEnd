using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.PrepararData
{

    public class Jornada
    {

        public int Id { get; set; }
        public List<Documento> Documentos { get; set; }
        public MovimientoCierre Cierre { get; set; }


        public Jornada()
        {
            Id = -1;
            Documentos = new List<Documento>();
            Cierre = new MovimientoCierre();
        }

    }

}