using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Usuario.Lista
{
    
    public class Filtro
    {

        public string IdGrupo { get; set; }


        public Filtro() 
        {
            Limpiar();
        }


        public void Limpiar()
        {
            IdGrupo = "";
        }

    }

}