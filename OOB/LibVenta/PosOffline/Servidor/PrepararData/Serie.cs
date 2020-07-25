using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.PrepararData
{
    
    public class Serie
    {

        public string Auto { get; set; }
        public string SerieNombre { get; set; }
        public string Control { get; set; }
        public int Correlativo { get; set; }


        public Serie()
        {
            Auto = "";
            SerieNombre = "";
            Control = "";
            Correlativo=0;
        }

    }

}