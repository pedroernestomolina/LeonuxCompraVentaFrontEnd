using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.ControlAcceso
{
    
    public class item
    {

        public string codFuncion { get; set; }
        public string funcion { get; set; }
        public bool estatus { get; set; }
        public string seguridad { get; set; }
        public string seguridadValor { get; set; }


        public item() 
        {
            codFuncion = "";
            funcion = "";
            estatus = false;
            seguridad = "";
            seguridadValor = "";
        }

    }

}