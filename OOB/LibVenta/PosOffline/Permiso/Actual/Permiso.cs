using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Permiso.Actual
{
    
    public class Permiso
    {

        public int Id { get; set; }
        public int Modulo { get; set; }
        public string Descripcion { get; set; }
        public bool RequiereClave { get; set; }
        public string CodigoFuncion { get; set; }


        public Permiso()
        {
            Id = -1;
            Modulo = 0;
            Descripcion = "";
            RequiereClave = false;
            CodigoFuncion = "";
        }

    }

}