using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Administrador.Documentos
{
    
    public class filtro: Reportes.Filtro.IFiltro
    {

        public bool ActivarSucursal
        {
            get { return false; }
        }

        public bool ActivarDesdeHasta
        {
            get { return false; }
        }

        public bool ActivarEstatus
        {
            get { return false; }
        }

        public bool ActivarMesAnoRelacion
        {
            get { return false; }
        }

        public bool ActivarCliente
        {
            get { return true ; }
        }

        public bool ActivarTipoDocumento
        {
            get { return false; }
        }

        public bool ValidarTipoDocumento
        {
            get { return false; }
        }

    }

}