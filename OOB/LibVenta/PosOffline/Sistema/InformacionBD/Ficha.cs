using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Sistema.InformacionBD
{
    
    public class Ficha
    {

        public string RemotoBD { get; set; }
        public string LocalBD { get; set; }


        public Ficha()
        {
            RemotoBD = "";
            LocalBD = "";
        }

    }

}