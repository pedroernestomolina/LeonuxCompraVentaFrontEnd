using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Permiso.Actual
{

    public class Ficha
    {

        public List<Permiso> Permisos { get; set; }


        public Ficha()
        {
            Permisos = new List<Permiso>();
        }

    }

}