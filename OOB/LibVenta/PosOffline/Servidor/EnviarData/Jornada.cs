using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.EnviarData
{
    
    public class Jornada
    {

        public int Id { get; set; }
        public string EstatusTransmitida { get; set; }


        public Jornada()
        {
            Id = -1;
            EstatusTransmitida="";
        }

    }

}