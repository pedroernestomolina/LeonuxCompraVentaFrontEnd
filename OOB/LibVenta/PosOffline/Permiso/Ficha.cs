using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Permiso
{
    
    public class Ficha
    {

        public bool IsHabilitado { get; set; }
        public Enumerados.enumNivelSeguridad NivelSeguridad { get; set; }

    }

}