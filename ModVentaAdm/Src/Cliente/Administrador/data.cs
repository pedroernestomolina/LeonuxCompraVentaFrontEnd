using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Cliente.Administrador
{
    
    public class data
    {

        private OOB.Maestro.Cliente.Entidad.Ficha _it;


        public string Id { get { return _it.Id; } }
        public string Codigo { get { return _it.Codigo; } }
        public string NombreRazonSocial { get { return _it.Nombre; } }
        public string CiRif { get { return _it.CiRif; } }


        public data(OOB.Maestro.Cliente.Entidad.Ficha it)
        {
            this._it = it;
        }

    }

}