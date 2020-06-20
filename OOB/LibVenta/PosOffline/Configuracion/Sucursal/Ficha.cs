using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Configuracion.Sucursal
{
    
    public class Ficha
    {

        public string Codigo { get; set; }
        public string EquipoNumero { get; set; }

        public string PrefijoSucursal 
        {
            get 
            {
                var t = "";
                t=Codigo + EquipoNumero;
                return t;
            }
        }

    }

}