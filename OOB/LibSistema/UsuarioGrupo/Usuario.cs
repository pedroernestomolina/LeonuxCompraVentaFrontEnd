using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.UsuarioGrupo
{
    
    public class Usuario
    {

        public string autoId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string codigo { get; set; }
        public string estatus { get; set; }
        public bool IsActivo { get { return estatus.Trim().ToUpper() == "ACTIVO"; } }


        public Usuario()
        {
            autoId = "";
            nombre = "";
            apellido = "";
            codigo = "";
            estatus = "";
        }

    }

}