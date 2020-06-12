using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Permiso.Actualizar
{

    public class Permiso
    {

        public int Id { get; set; }
        public bool RequiereClave { get; set; }


        public Permiso()
        {
            Id = -1;
            RequiereClave = false;
        }

    }

}