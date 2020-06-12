using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Permiso.Actualizar
{
    
    public class Ficha
    {

        public List<Permiso> Cambios { get; set; }


        public Ficha()
        {
            Cambios = new List<Permiso>();
        }

    }

}