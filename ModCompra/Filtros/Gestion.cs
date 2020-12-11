using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Filtros
{
    
    public class Gestion
    {

        private data aFiltrar;


        public DateTime? FechaDesde { get { return aFiltrar.FechaDesde ; } }
        public DateTime? FechaHasta { get { return aFiltrar.FechaHasta; } }
        public bool FechaIsOk { get { return aFiltrar.FechaIsOk(); } }


        public Gestion()
        {
            aFiltrar = new data();
        }


        public void Inicia() 
        {
            InicializarFiltros();
        }

        public void InicializarFiltros()
        {
            aFiltrar.InicializarFiltros();
        }

        public void setFechaDesde(DateTime fecha) 
        {
            aFiltrar.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            aFiltrar.setFechaHasta(fecha);
        }

    }

}