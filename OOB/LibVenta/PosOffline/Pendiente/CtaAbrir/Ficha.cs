using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Pendiente.CtaAbrir
{
    
    public class Ficha
    {

        public int IdCliente { get; set; }
        public List<OOB.LibVenta.PosOffline.Item.Ficha> Items{ get; set; }

    }

}
