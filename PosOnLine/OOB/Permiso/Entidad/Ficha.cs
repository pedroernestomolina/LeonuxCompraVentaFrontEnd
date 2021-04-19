using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Permiso.Entidad
{
    
    public class Ficha
    {


        public bool permisoHabilitado { get; set; }
        public bool requiereClave { get; set;}


        public Ficha()
        {
            permisoHabilitado = false;
            requiereClave = false;
        }

    }

}