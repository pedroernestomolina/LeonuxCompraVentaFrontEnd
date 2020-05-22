using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Usuario
{
    
    public class Ficha
    {

        public string Auto { get; set; }
        public string AutoGrupo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string CodigoGrupo { get; set; }
        public string DescripcionGrupo { get; set; }
        public bool IsActivo { get; set; }
        public bool IsInvitado { get; set; }

        public string Usuario 
        {
            get 
            {
                var rt = "";
                rt = Codigo + Environment.NewLine + Descripcion;
                return rt;
            }
        }

    }

}