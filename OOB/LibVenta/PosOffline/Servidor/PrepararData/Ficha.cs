using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.PrepararData
{
    
    public class Ficha
    {

        public List<Jornada> Jornadas { get; set; }


        public Ficha()
        {
            Jornadas = new List<Jornada>();
        }

    }

}